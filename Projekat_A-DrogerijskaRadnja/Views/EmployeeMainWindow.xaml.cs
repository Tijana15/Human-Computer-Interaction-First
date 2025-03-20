using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Projekat_A_DrogerijskaRadnja.Views
{
    /// <summary>
    /// Interaction logic for EmployeeMainWindow.xaml
    /// </summary>
    public partial class EmployeeMainWindow : Window
    {
        private Button activeButton = null;
        public EmployeeMainWindow()
        {
            InitializeComponent();
        }
        private void OnCategoriesClick(object sender, RoutedEventArgs e)
        {

            contentArea.Content = new CategoriesView();

            if (activeButton != null)
            {
                activeButton.Background = Brushes.Transparent;
            }

            activeButton = sender as Button;
            activeButton.Background = new SolidColorBrush(Color.FromRgb(72, 122, 122));
        }

        private void OnSellingItemsClick(object sender, RoutedEventArgs e)
        {
            
            if (activeButton != null)
            {
                activeButton.Background = Brushes.Transparent;
            }

            activeButton = sender as Button;
            activeButton.Background = new SolidColorBrush(Color.FromRgb(72, 122, 122));
        }

        private void OnBillingClick(object sender, RoutedEventArgs e)
        {
            if (activeButton != null)
            {
                activeButton.Background = Brushes.Transparent;
            }

            activeButton = sender as Button;
            activeButton.Background = new SolidColorBrush(Color.FromRgb(72, 122, 122));
        }

        private void OnBillsClick(object sender, RoutedEventArgs e)
        {
            if (activeButton != null)
            {
                activeButton.Background = Brushes.Transparent;
            }

            activeButton = sender as Button;
            activeButton.Background = new SolidColorBrush(Color.FromRgb(72, 122, 122));
        }

        private void OnSettingsClick(object sender, RoutedEventArgs e)
        {
            if (activeButton != null)
            {
                activeButton.Background = Brushes.Transparent;
            }

            activeButton = sender as Button;
            activeButton.Background = new SolidColorBrush(Color.FromRgb(72, 122, 122));
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
