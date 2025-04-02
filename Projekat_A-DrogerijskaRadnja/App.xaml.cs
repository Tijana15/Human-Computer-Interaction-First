using System;
using System.Windows;

namespace Projekat_A_DrogerijskaRadnja
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static void ChangeTheme(string themeName)
        {
            try
            {
                var themeUri = new Uri($"/Themes/{themeName}.xaml", UriKind.Relative);
                Current.Resources.MergedDictionaries.Clear();
                Current.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = themeUri });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška pri promjeni teme: {ex.Message}");
            }
        }
    }
}
