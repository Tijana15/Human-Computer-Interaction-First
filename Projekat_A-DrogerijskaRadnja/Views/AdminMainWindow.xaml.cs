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
                SetActiveButton(employeesButton);
            }

        }
        private void OnEmployeesClick(object sender, RoutedEventArgs e)
        {
            if (sender != activeButton) 
            {
                SetActiveButton(sender as Button);
                contentArea.Content = new EmployeesView();
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
