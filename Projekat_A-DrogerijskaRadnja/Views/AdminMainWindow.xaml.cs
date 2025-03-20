using System.Windows;

namespace Projekat_A_DrogerijskaRadnja.Views
{
    /// <summary>
    /// Interaction logic for AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        public AdminMainWindow()
        {
            InitializeComponent();
        }
        private void OnEmployeesClick(object sender, RoutedEventArgs e)
        {
            contentText.Text = "Employees Section";
        }

        private void OnSettingsClick(object sender, RoutedEventArgs e)
        {
            contentText.Text = "Settings Section";
        }

        private void OnLogoutClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Logging out...", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
