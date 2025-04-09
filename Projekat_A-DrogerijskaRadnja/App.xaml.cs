using System;
using System.Linq;
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
                var newResourceDictionary = new ResourceDictionary { Source = themeUri };
                var oldDictionaries = Application.Current.Resources.MergedDictionaries
                                 .Where(d => !d.Source?.OriginalString.Contains("/Themes/") ?? true)
                                 .ToList();
                Current.Resources.MergedDictionaries.Clear();
                Current.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = themeUri });
                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(newResourceDictionary);

                foreach (var dict in oldDictionaries)
                {
                    Application.Current.Resources.MergedDictionaries.Add(dict);
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        public static void ChangeLanguage(string language)
        {
            var languageUri=new Uri($"/Languages/{language}.xaml",UriKind.Relative);
            var newResourceDictionary = new ResourceDictionary { Source = languageUri };

            var oldDictionaries = Application.Current.Resources.MergedDictionaries
                                  .Where(d => !d.Source?.OriginalString.Contains("/Languages/") ?? true)
                                  .ToList();

            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(newResourceDictionary);

            foreach (var dict in oldDictionaries)
            {
                Application.Current.Resources.MergedDictionaries.Add(dict);
            }
        }
    }
}
