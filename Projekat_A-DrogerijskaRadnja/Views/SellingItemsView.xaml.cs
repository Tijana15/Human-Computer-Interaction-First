using Projekat_A_DrogerijskaRadnja.Model;
using Projekat_A_DrogerijskaRadnja.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Shapes;

namespace Projekat_A_DrogerijskaRadnja.Views
{
    public partial class SellingItemsView : UserControl
    {
        SellingItemService sellingItemService;
        List<SellingItem> sellingItems;

        public SellingItemsView()
        {
            InitializeComponent();
            sellingItemService = new SellingItemService();
            LoadSellingItems();
        }

        private void LoadSellingItems()
        {
            sellingItems = sellingItemService.GetAllSellingItems();
            sellingItemsList.ItemsSource = sellingItems;
        }

        private void OnAddSellingItemClick(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddNewSellingItem();
            addWindow.Show();
        }

        private void OnSearchButton(object sender, RoutedEventArgs e)
        {
            string searchText = searchBox.Text.Trim();

            if (!string.IsNullOrEmpty(searchText))
            {
                
                var filteredItems = sellingItems.Where(s =>
                    s.Product.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                    s.Product.Description.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                    s.Product.Brand.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                if (filteredItems.Any())
                {
                    sellingItemsList.ItemsSource = filteredItems;
                }
                else
                {
                    
                    MessageBox.Show("No matching products found.");
                }
            }
        }

        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
                searchBox.Text = "";
                searchBox.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void SearchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(searchBox.Text))
            {
                var placeholderText = (string)FindResource("SearchSellingItemText");
                searchBox.Text = placeholderText;
                searchBox.Foreground = (Brush)FindResource("UserSideBarBackground");
            }
        }

        private void OnShowAllButton(object sender, RoutedEventArgs e)
        {
            LoadSellingItems();
            searchBox.Clear();
        }

        private void SellingItemsList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (sellingItemsList.SelectedItem is SellingItem selectedItem)
            {
                var itemDetails = sellingItemService.GetSellingItemDetails(selectedItem.ProductId);
                if (itemDetails != null)
                {
                    string currentLanguage = Application.Current.Properties["Language"] as string;
                    string purchasePriceLabel = Application.Current.Resources["PurchasePriceText"] as string;
                    string purchaseDateLabel = Application.Current.Resources["PurchaseDateText"] as string;
                    string supplierLabel = Application.Current.Resources["SupplierText"] as string;

                    var detailsWindow = new Window
                    {
                        Title = Application.Current.Resources["ProductDetailsTitle"] as string ?? "Product Details",
                        Width = 400,
                        Height = 350,
                        ResizeMode = ResizeMode.NoResize,
                        WindowStartupLocation = WindowStartupLocation.CenterOwner,
                        Owner = Window.GetWindow(this),
                        Background = Brushes.WhiteSmoke
                    };

                    var mainGrid = new Grid
                    {
                        Margin = new Thickness(15)
                    };

                    var contentBorder = new Border
                    {
                        Background = Brushes.White,
                        BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E0E0E0")),
                        BorderThickness = new Thickness(1),
                        CornerRadius = new CornerRadius(8),
                        Effect = new DropShadowEffect
                        {
                            ShadowDepth = 1,
                            BlurRadius = 5,
                            Opacity = 0.2
                        }
                    };

                    var contentPanel = new StackPanel
                    {
                        Margin = new Thickness(20)
                    };

                    var headerPanel = new StackPanel
                    {
                        Orientation = Orientation.Horizontal,
                        Margin = new Thickness(0, 0, 0, 15)
                    };

                    var productIcon = new Border
                    {
                        Background = Application.Current.Resources["UserSideBarBackground"] as Brush,
                        Width = 40,
                        Height = 40,
                        CornerRadius = new CornerRadius(20),
                        VerticalAlignment = VerticalAlignment.Center
                    };

                    var productIdText = new TextBlock
                    {
                        Text = selectedItem.ProductId.ToString(),
                        FontWeight = FontWeights.SemiBold,
                        Foreground = Brushes.White,
                        FontSize = 16,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center
                    };
                    productIcon.Child = productIdText;
                    headerPanel.Children.Add(productIcon);

                    var productTitle = new TextBlock
                    {
                        Text = selectedItem.Product.Name,
                        FontWeight = FontWeights.Bold,
                        FontSize = 18,
                        Foreground = Application.Current.Resources["UserSideBarBackground"] as Brush,
                        VerticalAlignment = VerticalAlignment.Center,
                        Margin = new Thickness(15, 0, 0, 0)
                    };
                    headerPanel.Children.Add(productTitle);
                    contentPanel.Children.Add(headerPanel);

                    var separator = new Rectangle
                    {
                        Height = 1,
                        Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E0E7FF")),
                        Margin = new Thickness(0, 0, 0, 15)
                    };
                    contentPanel.Children.Add(separator);

                    AddDetailItem(contentPanel, Application.Current.Resources["DescriptionText"] as string, selectedItem.Product.Description);
                    AddDetailItem(contentPanel, Application.Current.Resources["BrandText"] as string, selectedItem.Product.Brand);

                    AddDetailItem(contentPanel, Application.Current.Resources["Price"] as string,
                        string.Format("${0:0.00}", selectedItem.Price));

                    if (currentLanguage == "Srpski")
                    {
                        AddDetailItem(contentPanel, purchasePriceLabel, string.Format("${0:0.00}", itemDetails.NabavnaCijena));
                        AddDetailItem(contentPanel, purchaseDateLabel, itemDetails.DatumNabavke.ToShortDateString());
                        AddDetailItem(contentPanel, supplierLabel, itemDetails.DobavljacNaziv);
                    }
                    else
                    {
                        AddDetailItem(contentPanel, "Purchase Price", string.Format("${0:0.00}", itemDetails.NabavnaCijena));
                        AddDetailItem(contentPanel, "Purchase Date", itemDetails.DatumNabavke.ToShortDateString());
                        AddDetailItem(contentPanel, "Supplier", itemDetails.DobavljacNaziv);
                    }

                    var buttonPanel = new StackPanel
                    {
                        Orientation = Orientation.Horizontal,
                        HorizontalAlignment = HorizontalAlignment.Right,
                        Margin = new Thickness(0, 15, 0, 0)
                    };

                    var closeButton = new Button
                    {
                        Content = Application.Current.Resources["CloseText"] as string ?? "Close",
                        Style = Application.Current.Resources["ActionButtonStyle"] as Style,
                        Foreground = Brushes.White,
                        Background = Application.Current.Resources["UserSideBarBackground"] as Brush,
                        FontWeight = FontWeights.SemiBold,
                        FontSize = 14,
                        BorderThickness = new Thickness(0),
                        Padding = new Thickness(15, 8, 15, 8),
                        MinWidth = 100
                    };
                    closeButton.Click += (s, args) => detailsWindow.Close();
                    buttonPanel.Children.Add(closeButton);
                    contentPanel.Children.Add(buttonPanel);

                    contentBorder.Child = contentPanel;
                    mainGrid.Children.Add(contentBorder);
                    detailsWindow.Content = mainGrid;
                    detailsWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show(
                        Application.Current.Resources["ProductDetailsNotFound"].ToString(),
                        Application.Current.Resources["ErrorTitle"].ToString(),
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
        }

        private void AddDetailItem(StackPanel panel, string label, string value)
        {
            var detailGrid = new Grid
            {
                Margin = new Thickness(0, 0, 0, 10)
            };

            detailGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            detailGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            var labelBlock = new TextBlock
            {
                Text = label,
                FontWeight = FontWeights.Bold,
                FontSize = 14,
                Margin = new Thickness(0, 0, 10, 0),
                VerticalAlignment = VerticalAlignment.Center
            };
            Grid.SetColumn(labelBlock, 0);

            var valueBlock = new TextBlock
            {
                Text = value,
                FontSize = 14,
                TextWrapping = TextWrapping.Wrap,
                VerticalAlignment = VerticalAlignment.Center
            };
            Grid.SetColumn(valueBlock, 1);

            detailGrid.Children.Add(labelBlock);
            detailGrid.Children.Add(valueBlock);
            panel.Children.Add(detailGrid);
        }

    }
}

