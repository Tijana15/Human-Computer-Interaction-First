using Projekat_A_DrogerijskaRadnja.Model;
using Projekat_A_DrogerijskaRadnja.Services;
using System.Collections.Generic;
using System.Windows;

namespace Projekat_A_DrogerijskaRadnja.Views
{
   public partial class AddNewSellingItem : Window
    {
        private List<Product> products = new List<Product>();
        public ProductService ProductService = new ProductService();
        private SellingItemService sellingItemService;

        private Product SelectedProduct => cmbProducts.SelectedItem as Product;
        public double Price => double.TryParse(txtPrice.Text, out double price) ? price : 0;

        public AddNewSellingItem()
        {
            InitializeComponent();
            sellingItemService = new SellingItemService();
            LoadProducts();
            
        }


        private void LoadProducts()
        {
            products = ProductService.GetAllProducts();
            cmbProducts.ItemsSource = products;
            cmbProducts.DisplayMemberPath = "Name";
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

        private void cmbProducts_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var selectedProduct = (Product)cmbProducts.SelectedItem;

            if (selectedProduct != null)
            {
                int selectedProductId = selectedProduct.ProductId;
                MessageBox.Show($"Selected Product ID: {selectedProductId}");
            }
        }
    }
}
