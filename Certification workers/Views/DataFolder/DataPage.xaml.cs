using Certification_workers.ViewModels;
using ExcelDataReader;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
    /// Логика взаимодействия для DataPage.xaml
    /// </summary>
    public partial class DataPage : Page
    {
        IExcelDataReader edr;

        public DataPage()
        {
            InitializeComponent();
            DataContext = new DataPageVM();
            DataContext = this;
        }

        private void OpenExcel_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
           // openFileDialog.Filter = "EXCEL Files (*.xlsx)|*.xlsx|EXCEL Files 2003 (*.xls)|*.xls|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true) 
            {
                DataGridCheckData.ItemsSource = readFile(openFileDialog.FileName);
            }
        }

        private DataView readFile(string fileNames)
        {
            var extension = fileNames.Substring(fileNames.LastIndexOf('.'));
            FileStream stream = File.Open(fileNames, FileMode.Open, FileAccess.Read);

            if (extension == ".xlsx")
                edr = ExcelReaderFactory.CreateOpenXmlReader(stream);

            else if (extension == ".xls")
                edr = ExcelReaderFactory.CreateBinaryReader(stream);

            var conf = new ExcelDataSetConfiguration
            {
                ConfigureDataTable = _ => new ExcelDataTableConfiguration
                {
                    UseHeaderRow = true
                }
            };

            DataSet dataSet = new DataSet();
            dataSet = edr.AsDataSet(conf);

            DataView dataView = new DataView();
            dataView = dataSet.Tables[0].AsDataView();

            edr.Close();
            return dataView;
        }

    }
}
