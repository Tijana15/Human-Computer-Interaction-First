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
            Loaded += AdminMainWindow_Loaded;
        }
        private void AdminMainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            contentArea.Content = new EmployeesView();

            if (employeesButton != null)
            {
                activeButton = employeesButton;
                activeButton.Background = new SolidColorBrush(Color.FromRgb(255, 182, 193));
            }
        }
        private void OnEmployeesClick(object sender, RoutedEventArgs e)
        {
            contentArea.Content = new EmployeesView();
            if (activeButton != null)
            {
                activeButton.Background = Brushes.Transparent;
            }

            activeButton = sender as Button;
            activeButton.Background = new SolidColorBrush(Color.FromRgb(255, 182, 193));

        }

        private void OnSettingsClick(object sender, RoutedEventArgs e)
        {
            contentArea.Content = "Settings Section";
            if (activeButton != null)
            {
                activeButton.Background = Brushes.Transparent;
            }

            activeButton = sender as Button;
            activeButton.Background = new SolidColorBrush(Color.FromRgb(255, 182, 193));
        }

        private void OnLogoutClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
