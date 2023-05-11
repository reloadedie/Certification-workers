using Certification_workers.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Certification_workers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static MainWindow window;

        public MainWindow()
        {
            InitializeComponent();
            window = this;
            DataContext = new MainWindowVM(window);

            MainWindowFrame.Content = new MainPage();
        }

        public static void MainNavigate(Page page)
        {
            window.MainWindowFrame.Navigate(page);
        }

        private void ListViewItemMouseEnter(object sender, MouseEventArgs e)
        {
            // Set tooltip visibility

            if (ToggleButtonMainWindow.IsChecked == true)
            {
                ToolTipWorkers.Visibility = Visibility.Collapsed;
                ToolTipData.Visibility = Visibility.Collapsed;
                ToolTipInformation.Visibility = Visibility.Collapsed;
                ToolTipMain.Visibility = Visibility.Collapsed;

                ToolTipSettings.Visibility = Visibility.Collapsed;
            }
            else
            {
                ToolTipWorkers.Visibility = Visibility.Visible;
                ToolTipData.Visibility = Visibility.Visible;
                ToolTipInformation.Visibility = Visibility.Visible;
                ToolTipMain.Visibility = Visibility.Visible;

                ToolTipSettings.Visibility = Visibility.Visible;
            }

        }

        private void ToggleButtonChecked(object sender, RoutedEventArgs e)
        {

        }

        private void ToggleButtonUnchecked(object sender, RoutedEventArgs e)
        {

        }
    }
}
