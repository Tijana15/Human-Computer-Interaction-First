using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;


namespace Projekat_A_DrogerijskaRadnja.Views
{
    /// <summary>
    /// Interaction logic for AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        private Button activeButton = null;
        public AdminMainWindow()
        {
            InitializeComponent();
        }
        private void OnEmployeesClick(object sender, RoutedEventArgs e)
        {
            contentArea.Content = new EmployeesView();
            if (activeButton != null)
            {
                activeButton.Background = Brushes.Transparent;
            }

            activeButton = sender as Button;
            //activeButton.Background = new SolidColorBrush();

        }

        private void OnSettingsClick(object sender, RoutedEventArgs e)
        {
            contentArea.Content = "Settings Section";
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
