using Projekat_A_DrogerijskaRadnja.Services;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Projekat_A_DrogerijskaRadnja.Views
{
    public partial class MainWindow : Window
    {
        private readonly AccountService accountService;
        private string username;
        private string password;
        public MainWindow()
        {
            InitializeComponent();
            accountService = new AccountService();
            App.ChangeLanguage("English");

        }

        private void OnSignIn(object sender, RoutedEventArgs e)
        {
            username = usernameTxt.Text;
            password = passwordTxt.Password;
            var accounts = accountService.getAccounts();
            var accountExists = accounts.Any(n => n.KorisnickoIme == username && n.Lozinka == password);

            if (accountExists)
            {
                if (username == "tijana.lazendic")
                {
                    AdminMainWindow adminWindow = new AdminMainWindow();
                    adminWindow.Show();
                }
                else
                {
                    EmployeeMainWindow empWindow = new EmployeeMainWindow();
                    empWindow.Show();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect password or username. Try again.",
                                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                usernameTxt.Clear();
                passwordTxt.Clear();
            }
        }
        private void ClearPlaceholderText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && (textBox.Text == "Username" || textBox.Text=="Korisničko ime"))
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black;
            }
        }

        private void RestorePlaceholderText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Username";
                textBox.Foreground = Brushes.Gray;
            }
        }

        private void ClearPasswordPlaceholder(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            if (passwordBox != null && passwordBox.Password == "Password")
            {
                passwordBox.Password = string.Empty;
                passwordBox.Foreground = Brushes.Black;
            }
        }

        private void RestorePasswordPlaceholder(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            if (passwordBox != null && string.IsNullOrWhiteSpace(passwordBox.Password))
            {
                passwordBox.Password = "Password";
                passwordBox.Foreground = Brushes.Gray;
            }
        }
        private void OnSerbianLanguage(object sender, RoutedEventArgs e)
        {
            btnBosnian.Background = (Brush)FindResource("ButtonColor");
            btnBosnian.Opacity = 1;

            btnEnglish.Background = (Brush)FindResource("DeleteButtonColor");
            btnEnglish.Opacity = 0.6;

            App.ChangeLanguage("Srpski");
            
        }

        private void OnEnglishLanguage(object sender, RoutedEventArgs e)
        {
            btnEnglish.Background = (Brush)FindResource("ButtonColor");
            btnEnglish.Opacity = 1;

            btnBosnian.Background = (Brush)FindResource("DeleteButtonColor");
            btnBosnian.Opacity = 0.6;

            App.ChangeLanguage("English");
            
        }
    }
}
