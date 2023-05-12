using Certification_workers.ViewModels.WorkersVMFolder;
using ExcelDataReader;
using Microsoft.Win32;
using System;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace Certification_workers.Views
{
    /// <summary>
    /// Логика взаимодействия для WorkersPage.xaml
    /// </summary>
    public partial class WorkersPage : Page
    {
        IExcelDataReader edr;

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
