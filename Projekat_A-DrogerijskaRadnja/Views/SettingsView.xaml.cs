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
            newTheme.Source = new Uri($"Themes/{themeName}.xaml", UriKind.Relative);
            Application.Current.Resources.MergedDictionaries.Add(newTheme);

        }
    }
}
