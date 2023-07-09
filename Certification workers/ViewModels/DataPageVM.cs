using Certification_workers.Core;
using System;
using System.Windows;

namespace Certification_workers.ViewModels
{
    public class DataPageVM : BaseNotify
    {
        public string PathToFile { get; set; }

        public CoreCommand ReadFile { get; set; }
        public CoreCommand GenerateFile { get; set; }
        public CoreCommand SynchronizeFile { get; set; }

        public DataPageVM()
        {
            ReadFile = new CoreCommand(() =>
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

            GenerateFile = new CoreCommand(() =>
            {
                try
                {
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            });

            SynchronizeFile = new CoreCommand(() =>
            {
                try
                {

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            });
        }

        private static void OpenExcelFile()
        {

        }

    }
}
