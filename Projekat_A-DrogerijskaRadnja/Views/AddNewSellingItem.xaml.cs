using Projekat_A_DrogerijskaRadnja.Model;
using Projekat_A_DrogerijskaRadnja.Services;
using System.Collections.Generic;
using System.Windows;

namespace Projekat_A_DrogerijskaRadnja.Views
{
   public partial class AddNewSellingItem : Window
    {
        private List<Product> products = new List<Product>();
        //private List<Purchase> purchases = new List<Purchase>();

       // public ProductService productService = new ProductService();
        //public PurchaseService purchaseService = new PurchaseService();
        private SellingItemService sellingItemService;

        private Product SelectedProduct => cmbProducts.SelectedItem as Product;
        //private Purchase SelectedPurchase => cmbPurchases.SelectedItem as Purchase;
        public double Price => double.TryParse(txtPrice.Text, out double price) ? price : 0;

        public AddNewSellingItem()
        {
            InitializeComponent();
            sellingItemService = new SellingItemService();
            LoadProducts();
            LoadPurchases();
        }

        private void LoadProducts()
        {
            //products = productService.GetProducts();
            cmbProducts.ItemsSource = products;
            cmbProducts.DisplayMemberPath = "Name";
        }

        private void LoadPurchases()
        {
            //purchases = purchaseService.GetPurchases();
            //cmbPurchases.ItemsSource = purchases;
            cmbPurchases.DisplayMemberPath = "Id";
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                /*var selectedProduct = cmbProducts.SelectedItem as Product;
                var selectedPurchase = cmbPurchases.SelectedItem as Purchase;

                var newSellingItem = new SellingItem
                {
                    PROIZVOD_IdProizvod = selectedProduct.Id_Product,
                    STAVKA_NABAVKE_NABAVLJANJE_IdNabavke = selectedPurchase.Id_Purchase,
                    Cijena = Price
                };

                sellingItemService.AddSellingItem(newSellingItem);
                Close();
                */

            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private bool ValidateInput()
        {
            if (cmbProducts.SelectedItem == null)
            {
                MessageBox.Show("Select a product and try again.");
                return false;
            }
            if (cmbPurchases.SelectedItem == null)
            {
                MessageBox.Show("Select a purchase and try again.");
                return false;
            }
            if (Price <= 0)
            {
                MessageBox.Show("Enter a valid price.");
                return false;
            }

            return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
