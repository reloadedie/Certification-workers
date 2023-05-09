using Certification_workers.ViewModels.WorkersVMFolder;
using System.Windows;

namespace Certification_workers.Views.WorkersFolder
{
    /// <summary>
    /// Логика взаимодействия для WorkersWindow.xaml
    /// </summary>
    public partial class WorkersWindow : Window
    {
        public WorkersWindow()
        {
            InitializeComponent();
            DataContext = new WorkersWindowVM();
        }
    }
}
