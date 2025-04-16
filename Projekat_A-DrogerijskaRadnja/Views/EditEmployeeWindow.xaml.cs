using Projekat_A_DrogerijskaRadnja.Model;
using Projekat_A_DrogerijskaRadnja.Services;
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
            var deleteMessage = Application.Current.Resources["DeleteEmployeeMessage"].ToString();
            var confirmTitle = Application.Current.Resources["DeleteEmployeeConfirmTitle"].ToString();

            var result = MessageBox.Show(deleteMessage, confirmTitle, MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                employeeService.DeleteEmployee(Employee.EmployeeId);
            }

            this.Close();
        }

    }
}
