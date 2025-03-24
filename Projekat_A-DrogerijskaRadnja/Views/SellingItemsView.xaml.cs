using Projekat_A_DrogerijskaRadnja.Model;
using Projekat_A_DrogerijskaRadnja.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
                    s.Product.Name.ToLower().Contains(searchText) ||
                    s.Product.Description.ToLower().Contains(searchText) ||
                    s.Product.Brand.ToLower().Contains(searchText))
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
            if (searchBox.Text == "Search a product...")
            {
                searchBox.Text = "";
                searchBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void SearchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(searchBox.Text))
            {
                searchBox.Text = "Search a product...";
                searchBox.Foreground = new SolidColorBrush(Colors.Gray);
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
                //var editWindow = new EditSellingItemWindow(selectedItem);
                // editWindow.ShowDialog();
            }
        }
    }
}

