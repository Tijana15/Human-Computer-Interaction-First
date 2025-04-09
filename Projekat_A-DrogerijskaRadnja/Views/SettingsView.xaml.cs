using Projekat_A_DrogerijskaRadnja.Services;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Projekat_A_DrogerijskaRadnja.Views
{
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
            var currentTheme = Application.Current.Resources.MergedDictionaries.FirstOrDefault(d => d.Source != null && d.Source.ToString().Contains("Theme"));
            if (currentTheme != null)
            {
                string themeFile = currentTheme.Source.ToString();

                if (themeFile.Contains("NightTheme"))
                    themeComboBox.SelectedIndex = 1; 
                else if (themeFile.Contains("LightTheme") && !themeFile.Contains("Normal"))
                    themeComboBox.SelectedIndex = 2; 
                else
                    themeComboBox.SelectedIndex = 0; 
            }
        }

        private void OnSaveChangesClick(object sender, RoutedEventArgs e)
        {
            var themeName = "";
            if (themeComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
               
                if (selectedItem.Content.ToString() == "Dark")
                {
                    themeName = "NightTheme";
                }
                else if (selectedItem.Content.ToString() == "Light")
                {
                    themeName = "LightTheme";
                }
                else
                {
                    themeName = "NormalLightTheme";
                }
            }
            ResourceDictionary currentTheme = Application.Current.Resources.MergedDictionaries.FirstOrDefault(d => d.Source != null && d.Source.ToString().Contains("Theme"));

            if (currentTheme != null)
                Application.Current.Resources.MergedDictionaries.Remove(currentTheme);

            ResourceDictionary newTheme = new ResourceDictionary();
            newTheme.Source = new Uri($"/Themes/{themeName}.xaml", UriKind.Relative);
            Application.Current.Resources.MergedDictionaries.Add(newTheme);

            var username = Application.Current.Properties["Username"] as string;
            var password = Application.Current.Properties["Password"] as string;
         
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                var service = new AccountService();
                service.UpdateThemeForUser(username, password, themeName);
            }
        }

    }
}
