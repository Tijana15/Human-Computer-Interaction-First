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
    public partial class EmployeesView : UserControl
    {
        EmployeeService employeeService;
        List<Employee> employees;

        public EmployeesView()
        {
            InitializeComponent();
            employeeService = new EmployeeService();
            LoadEmployees();
        }

        public void LoadEmployees()
        {
            employees = employeeService.GetEmployees();
            employeesPanel.ItemsSource = employees;
        }

        private void OnAddEmployeeClick(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddNewEmployee();
            bool? result = addWindow.ShowDialog();

            if (result == true)
            {
                LoadEmployees();
            }

        }

        private void OnSearchButton(object sender, RoutedEventArgs e)
        {
            string searchText = searchBox.Text.Trim();

            if (!string.IsNullOrEmpty(searchText))
            {
                var filteredEmployees = employees.FindAll(emp => emp.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase));

                if (filteredEmployees.Any())
                {
                    employeesPanel.ItemsSource = filteredEmployees;
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
                var placeholderText = (string)FindResource("SearchAnEmployee");
                searchBox.Text = placeholderText;
                searchBox.Foreground = (Brush)FindResource("SidebarBackground");
            }
        }

        private void OnShowAllButton(object sender, RoutedEventArgs e)
        {
            LoadEmployees();
            searchBox.Clear();
            var placeholderText = (string)FindResource("SearchAnEmployee");
            searchBox.Text = placeholderText;
            searchBox.Foreground = (Brush)FindResource("SidebarBackground");

        }

        private void OnEmployeeDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.OriginalSource is FrameworkElement element && element.DataContext is Employee selectedEmployee)
            {
                var editWindow = new EditEmployeeWindow(selectedEmployee);
                editWindow.ShowDialog();
                LoadEmployees(); 
            }
        }
    }
}
