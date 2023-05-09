using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Certification_workers.Views
{
    /// <summary>
    /// Логика взаимодействия для SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void ToggleButtonChecked(object sender, RoutedEventArgs e)
        {
            var uriLight = new Uri(@"Themes/LightTheme.xaml", UriKind.Relative);

            ResourceDictionary resourceDictionary = Application.LoadComponent(uriLight) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
        }

        private void ToggleButtonUnchecked(object sender, RoutedEventArgs e)
        {
            var uriDark = new Uri(@"Themes/DarkTheme.xaml", UriKind.Relative);

            ResourceDictionary resourceDictionary = Application.LoadComponent(uriDark) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
        }

        private void ButtonDarkTheme_Click(object sender, RoutedEventArgs e)
        {
            var uriDark = new Uri(@"Themes/DarkTheme.xaml", UriKind.Relative);

            ResourceDictionary resourceDictionary = Application.LoadComponent(uriDark) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);

        }

        private void ButtonLightTheme_Click(object sender, RoutedEventArgs e)
        {
            var uriLight = new Uri(@"Themes/LightTheme.xaml", UriKind.Relative);

            ResourceDictionary resourceDictionary = Application.LoadComponent(uriLight) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);

        }
    }
}
