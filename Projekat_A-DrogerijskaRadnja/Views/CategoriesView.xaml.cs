using Projekat_A_DrogerijskaRadnja.Model;
using Projekat_A_DrogerijskaRadnja.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Projekat_A_DrogerijskaRadnja.Views
{
    public partial class CategoriesView : UserControl
    {
        CategoryService categoriesService;
        List<Category> categories;
        public CategoriesView()
        {
            InitializeComponent();
            categoriesService=new CategoryService();  
            LoadCategories();
        }
        private void LoadCategories()
        {
            categories= categoriesService.GetCategories();
            categoriesList.ItemsSource = categories;
        }
        private void OnAddCategoryClick(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddNewCategory();
            addWindow.Show();
            
        }
        private void OnCategoryDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (categoriesList.SelectedItem is Category selectedCategory)
            {
                var editWindow = new EditCategoryWindow(selectedCategory);
                editWindow.ShowDialog();
            }
        }
        private void OnSearchButton(object sender, RoutedEventArgs e)
        {
            string searchText = searchBox.Text.Trim();

            if (!string.IsNullOrEmpty(searchText))
            {
                var filteredCategories = categories.FindAll(c => c.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase));

                if (filteredCategories.Any())
                {
                    categoriesList.ItemsSource = filteredCategories;
                }
            }
        }
        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (searchBox.Text == "Search a category...")
            {
                searchBox.Text = "";
                searchBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }
        private void SearchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(searchBox.Text))
            {
                searchBox.Text = "Search a category...";
                searchBox.Foreground = new SolidColorBrush(Colors.Gray); 
            }
        }
        private void OnShowAllButton(object sender, RoutedEventArgs e)
        {
            LoadCategories();
            searchBox.Clear();
        }
    }
}

