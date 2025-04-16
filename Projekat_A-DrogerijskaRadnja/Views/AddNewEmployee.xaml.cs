using Projekat_A_DrogerijskaRadnja.Model;
using Projekat_A_DrogerijskaRadnja.Services;
using System;
using System.Windows;

namespace Projekat_A_DrogerijskaRadnja.Views
{

    public partial class AddNewEmployee : Window
    {
        readonly EmployeeService employeeService;
        public AddNewEmployee()
        {
            InitializeComponent();
            employeeService = new EmployeeService();
        }

        private void OnSaveClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                string.IsNullOrWhiteSpace(LastNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(TelephoneTextBox.Text) ||
                string.IsNullOrWhiteSpace(AddressTextBox.Text) ||
                string.IsNullOrWhiteSpace(ShiftTextBox.Text) ||
                string.IsNullOrWhiteSpace(ObligationTextBox.Text) ||
                string.IsNullOrWhiteSpace(SalaryTextBox.Text) ||
                string.IsNullOrWhiteSpace(HireDateTextBox.Text))
            {
                MessageBox.Show("All fields must be filled out!", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!double.TryParse(SalaryTextBox.Text, out var salary))
            {
                MessageBox.Show("Invalid salary format!", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!DateTime.TryParse(HireDateTextBox.Text, out var hireDate))
            {
                MessageBox.Show("Invalid date format! Please enter a valid date.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            var employee = new Employee
            {
                Name = NameTextBox.Text,
                LastName = LastNameTextBox.Text,
                Telephone = TelephoneTextBox.Text,
                Address = AddressTextBox.Text,
                Shift = ShiftTextBox.Text,
                Obligation = ObligationTextBox.Text,
                Salary = salary,
                HireDate = hireDate
            };

            if (employeeService.AddEmployee(employee))
            {
                MessageBox.Show("Employee saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.DialogResult = true;
                this.Close();
                
            }
            else
            {
                MessageBox.Show("Error occured. Try again later.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
