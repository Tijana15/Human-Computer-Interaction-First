using Projekat_A_DrogerijskaRadnja.Model;
using Projekat_A_DrogerijskaRadnja.Services;
using System;
using System.Windows;

namespace Projekat_A_DrogerijskaRadnja.Views
{
    public partial class EditEmployeeWindow : Window
    {
        public Employee Employee { get; set; }
        private readonly EmployeeService employeeService;

        public EditEmployeeWindow(Employee selectedEmployee)
        {
            InitializeComponent();
            Employee = selectedEmployee;
            employeeService = new EmployeeService();
            DataContext = this;
        }

        private void OnUpdateClick(object sender, RoutedEventArgs e)
        {
            employeeService.UpdateEmployee(Employee);
            this.Close();
        }

        private void OnDeleteClick(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this employee? This action cannot be undone.", "Confirm",
                                         MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                 employeeService.DeleteEmployee(Employee.EmployeeId);
            }
            this.Close ();
        }
    }
}
