using Certification_workers.Core;
using ExcelDataReader;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Certification_workers.ViewModels
{
    public class DataPageVM : BaseNotify
    {
        public string PathToFile { get; set; }

        public CoreCommand DownloadFile { get; set; }

        public DataPageVM()
        {
            DownloadFile = new CoreCommand(() =>
            {
                try
                {
                    OpenExcelFile();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            });
        }

        private void OpenExcelFile()
        {

        }

    }
}
