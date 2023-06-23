using Certification_workers.LocalDB;
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

namespace Certification_workers.Views.WorkersFolder
{
    /// <summary>
    /// Логика взаимодействия для EditWorkerWindow.xaml
    /// </summary>
    public partial class EditWorkerWindow : Window
    {
        EditWorkerWindow editWorkerWindow;

        public EditWorkerWindow()
        {
            InitializeComponent();
            DataContext = new EditWorkerWindowVM(null);
        }

        public EditWorkerWindow(Worker worker)
        {
            InitializeComponent();
            DataContext = new EditWorkerWindowVM(worker);
        }

        private void CanselCloseClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
