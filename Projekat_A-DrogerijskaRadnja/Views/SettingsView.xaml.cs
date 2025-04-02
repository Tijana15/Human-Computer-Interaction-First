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
                string themeName = selectedItem.Content.ToString() == "Dark"
                    ? "NightTheme"
                    : "NormalLightTheme";

                App.ChangeTheme(themeName);
                MessageBox.Show($"Tema promijenjena u {selectedItem.Content}!", "Obavještenje");
            }
        }
    }
}
