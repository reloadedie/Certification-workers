using Certification_workers.ViewModels;
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
using System.Windows.Shapes;

namespace Certification_workers.Views
{
    /// <summary>
    /// Логика взаимодействия для InfoWindow.xaml
    /// </summary>
    public partial class InfoWindow : Window
    {
        static InfoWindow window;

        public InfoWindow()
        {
            InitializeComponent();
            window = this;
            DataContext = new InfoWindowVM();
        }

        public static void MainNavigate(Page page)
        {
            window.InfoQuestionsFrame.Navigate(page);
        }
    }
}
