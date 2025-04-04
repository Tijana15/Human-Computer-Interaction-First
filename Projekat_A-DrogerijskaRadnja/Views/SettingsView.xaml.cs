using System;
using System.Windows;
using System.Windows.Controls;

namespace Projekat_A_DrogerijskaRadnja.Views
{
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
        }

        private void OnSaveChangesClick(object sender, RoutedEventArgs e)
        {
            if (themeComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                var themeName = "";
               if(selectedItem.Content.ToString() == "Dark")
                {
                    themeName = "NightTheme";
                }
                else if(selectedItem.Content.ToString()== "Light")
                {
                    themeName = "LightTheme";
                }
                else
                {
                    themeName = "NormalLightTheme";
                }
                   
                App.ChangeTheme(themeName);
                MessageBox.Show($"Tema promijenjena u {selectedItem.Content}!", "Obavještenje");
            }
            if(languageComboBox.SelectedItem is ComboBoxItem languageItem)
            {
                var language = "";
                if (languageItem.Content.ToString() == "English")
                {
                    language = "English";
                }
                else
                {
                    language = "Srpski";
                }
                App.ChangeLanguage(language);
            }
        }
    }
}
