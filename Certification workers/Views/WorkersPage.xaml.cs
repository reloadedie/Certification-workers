using Certification_workers.ViewModels.WorkersVMFolder;
using System.Windows;
using System.Windows.Controls;

namespace Certification_workers.Views
{
    /// <summary>
    /// Логика взаимодействия для WorkersPage.xaml
    /// </summary>
    public partial class WorkersPage : Page
    {
        public WorkersPage()
        {
            InitializeComponent();
            DataContext = new WorkersPageVM();
        }

        private void ToggleButtonChecked(object sender, RoutedEventArgs e)
        {

        }

        private void ToggleButtonUnchecked(object sender, RoutedEventArgs e)
        {

        }
    }
}
