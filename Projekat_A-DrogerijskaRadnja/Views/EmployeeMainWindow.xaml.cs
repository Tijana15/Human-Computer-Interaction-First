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
            Loaded += EmployeeMainWindow_Loaded;
            
        }
        
        private void EmployeeMainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            contentArea.Content = new CategoriesView();

            if (categoriesButton != null)
            {
                SetActiveButton(categoriesButton);
            }
        }
        private void OnCategoriesClick(object sender, RoutedEventArgs e)
        {

            if (sender != activeButton) 
            {
                SetActiveButton(sender as Button);
                contentArea.Content = new CategoriesView();
            }
        }

        private void OnSellingItemsClick(object sender, RoutedEventArgs e)
        {
            if (sender != activeButton)
            {
                SetActiveButton(sender as Button);
                contentArea.Content = new SellingItemsView();
            }
        }

        private void OnBillingClick(object sender, RoutedEventArgs e)
        {
            if (sender != activeButton) 
            {
                SetActiveButton(sender as Button);
                //contentArea.Content = new EmployeesView();
            }
        }

        private void OnBillsClick(object sender, RoutedEventArgs e)
        {
            if (sender != activeButton) 
            {
                SetActiveButton(sender as Button);
                contentArea.Content = new BillsOverview();
            }
        }

        private void OnSettingsClick(object sender, RoutedEventArgs e)
        {
            if (sender != activeButton) 
            {
                SetActiveButton(sender as Button);
                contentArea.Content = new SettingsView();
            }
        }

        private void OnLogoutClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Logging out...", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void SetActiveButton(Button newActiveButton)
        {
            if (activeButton != null)
            {
                activeButton.Background = Brushes.Transparent;
                activeButton.Foreground = Brushes.White;
            }

            activeButton = newActiveButton;

            if (activeButton != null)
            {
                activeButton.Background = Brushes.LightGray;
                activeButton.Foreground = Brushes.Black;
            }
        }

    }
}
