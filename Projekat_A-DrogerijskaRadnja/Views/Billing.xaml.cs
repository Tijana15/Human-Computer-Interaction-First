using Projekat_A_DrogerijskaRadnja.Model;
using Projekat_A_DrogerijskaRadnja.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Projekat_A_DrogerijskaRadnja.Views
{
  
    public partial class Billing : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private SellingItemService sellingItemService;
        private CashRegisterService cashRegisterService;
        private BillItemBaseService billItemBaseService;
        private BillService billService;

        private ObservableCollection<SellingItem> _allSellingItems;
        private ObservableCollection<BillItemViewModel> _billItems;
        private ObservableCollection<CashRegister> _cashRegisters;
        private DateTime _currentDateTime;
        private double _totalAmount;

        public class BillItemViewModel : BaseBillItem, INotifyPropertyChanged
        {
            public string _productName;

            public string ProductName
            {
                get => _productName;
                set
                {
                    _productName = value;
                    OnPropertyChanged(nameof(ProductName));
                }
            }

            public double TotalPrice => SellingPrice * Amount;

            public event PropertyChangedEventHandler PropertyChanged;

            public void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ObservableCollection<SellingItem> AllSellingItems
        {
            get => _allSellingItems;
            set
            {
                _allSellingItems = value;
                OnPropertyChanged(nameof(AllSellingItems));
            }
        }

        public ObservableCollection<BillItemViewModel> BillItems
        {
            get => _billItems;
            set
            {
                _billItems = value;
                OnPropertyChanged(nameof(BillItems));
            }
        }

        public ObservableCollection<CashRegister> CashRegisters
        {
            get => _cashRegisters;
            set
            {
                _cashRegisters = value;
                OnPropertyChanged(nameof(CashRegisters));
            }
        }

        public DateTime CurrentDateTime
        {
            get => _currentDateTime;
            set
            {
                _currentDateTime = value;
                OnPropertyChanged(nameof(CurrentDateTime));
            }
        }

        public double TotalAmount
        {
            get => _totalAmount;
            set
            {
                _totalAmount = value;
                txtTotalAmount.Text = $"{_totalAmount:N2} KM";
                OnPropertyChanged(nameof(TotalAmount));
            }
        }

        public Billing()
        {
            InitializeComponent();

            sellingItemService = new SellingItemService();
            cashRegisterService = new CashRegisterService();
            billItemBaseService = new BillItemBaseService();
            billService= new BillService();

            AllSellingItems = new ObservableCollection<SellingItem>();
            BillItems = new ObservableCollection<BillItemViewModel>();
            CashRegisters = new ObservableCollection<CashRegister>();

            CurrentDateTime = DateTime.Now;

            DataContext = this;
            listProducts.ItemsSource = AllSellingItems;
            listBillItems.ItemsSource = BillItems;
            comboCashRegister.ItemsSource = CashRegisters;
            comboCashRegister.DisplayMemberPath = "CashRegisterId";
            comboCashRegister.SelectedValuePath = "CashRegisterId";
            comboPaymentMethod.SelectedIndex = 0;

            LoadData();
        }

        private void LoadData()
        {
                var sellingItems = sellingItemService.GetAllSellingItems();
                AllSellingItems.Clear();
                foreach (var item in sellingItems)
                {
                    AllSellingItems.Add(item);
                }

                var cashRegs = cashRegisterService.getRegisters();
                CashRegisters.Clear();
                foreach (var cashRegister in cashRegs)
                {
                    CashRegisters.Add(cashRegister);
                }

                if (CashRegisters.Count > 0)
                {
                    comboCashRegister.SelectedIndex = 0;
                }
        }

        private void RefreshData_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
            CurrentDateTime = DateTime.Now;
        }

        private void ListProducts_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (listProducts.SelectedItem is SellingItem selectedItem)
            {
                AddToCart(selectedItem);
            }
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is SellingItem selectedItem)
            {
                AddToCart(selectedItem);
            }
        }

        private void AddToCart(SellingItem item)
        {
            var existingItem = BillItems.FirstOrDefault(i => i.ProductId == item.ProductId);

            if (existingItem != null)
            {
                existingItem.Amount++;
                existingItem.OnPropertyChanged(nameof(existingItem.Amount));
                existingItem.OnPropertyChanged(nameof(existingItem.TotalPrice));
                OnPropertyChanged(nameof(BillItems));
            }
            else
            {
                BillItems.Add(new BillItemViewModel
                {
                    ProductId = item.ProductId,
                    BillId = 0,
                    Amount = 1,
                    SellingPrice = item.Price,
                    ProductName = item.Product?.Name ?? $"Proizvod {item.ProductId}"
                });
            }

            UpdateTotalAmount();
        }

        private void IncreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is BillItemViewModel billItem)
            {
                billItem.Amount++;
                billItem.OnPropertyChanged(nameof(billItem.Amount));
                billItem.OnPropertyChanged(nameof(billItem.TotalPrice));
                OnPropertyChanged(nameof(BillItems));
                UpdateTotalAmount();
            }
        }

        private void DecreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is BillItemViewModel billItem)
            {
                if (billItem.Amount > 1)
                {
                    billItem.Amount--;
                    billItem.OnPropertyChanged(nameof(billItem.Amount));
                    billItem.OnPropertyChanged(nameof(billItem.TotalPrice));
                }
                else
                {
                    BillItems.Remove(billItem);
                }

                UpdateTotalAmount();
            }
        }

        private void UpdateTotalAmount()
        {
            TotalAmount = BillItems.Sum(item => item.TotalPrice);
        }

        private void CreateBill_Click(object sender, RoutedEventArgs e)
        {
            if (BillItems.Count == 0)
            {
                MessageBox.Show(Application.Current.Resources["WarningMessage"].ToString(), "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (comboCashRegister.SelectedItem == null)
            {
                MessageBox.Show(Application.Current.Resources["SelectCashRegisterMessage"].ToString(), "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var selectedCashRegister = comboCashRegister.SelectedItem as CashRegister;
                int cashRegisterIdS = selectedCashRegister != null ? selectedCashRegister.CashRegisterId : 0;

                BillService billService = new BillService();
                BillItemBaseService itemService = new BillItemBaseService();

                Bill newBill = new Bill(
                    billId: 0,
                    dateTime: DateTime.Now,
                    payingMethod: ((ComboBoxItem)comboPaymentMethod.SelectedItem).Content.ToString(),
                    price: TotalAmount,
                    cashRegisterId: cashRegisterIdS,
                    accountId: 1
                );

                int billId = billService.CreateBill(newBill);

                foreach (var item in BillItems)
                {
                    BaseBillItem billItem = new BaseBillItem
                    {
                        ProductId = item.ProductId,
                        BillId = billId,
                        Amount = item.Amount,
                        SellingPrice = item.SellingPrice
                    };

                    itemService.AddBillItem(billItem);
                }
                var successWindow = new Window
                {
                    Title = Application.Current.Resources["SuccessTitle"].ToString(), 
                    Width = 300,
                    Height = 150,
                    ResizeMode = ResizeMode.NoResize,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner,
                    Owner = Window.GetWindow(this), 
                    Content = new StackPanel
                    {
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Children =
            {
                new TextBlock
                {
                    Text = "✔", 
                    FontSize = 36,
                    Foreground = Brushes.Green,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(0, 0, 0, 10)
                },
                new TextBlock
                {
                    Text = Application.Current.Resources["CreateBillSuccessMessage"].ToString(), 
                    FontSize = 16,
                    TextWrapping = TextWrapping.Wrap,
                    TextAlignment = TextAlignment.Center
                }
            }
                    }
                };
                successWindow.Show();
                BillItems.Clear();
                TotalAmount = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Application.Current.Resources["CreateBillInfoMessage"].ToString(), "Informacija", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}