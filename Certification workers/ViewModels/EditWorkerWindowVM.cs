using Certification_workers.Core;
using Certification_workers.LocalDB;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Certification_workers.ViewModels
{
    public class EditWorkerWindowVM : BaseNotify
    {
        CertificationWorkersContext db = new CertificationWorkersContext();

        private Worker selectedWorker;
        public Worker SelectedWorker
        {
            get => selectedWorker;
            set
            {
                selectedWorker = value;
                SignalChanged();
            }
        }
        
        public CoreCommand DownloadImagePhotoWorker { get; set; }
        public CoreCommand SaveWorker { get; set; }

        public EditWorkerWindowVM(Worker worker)
        {
            SelectedWorker = worker;

            DownloadImagePhotoWorker = new CoreCommand(() =>
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter =
                               "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
                ofd.FilterIndex = 1;
                if (ofd.ShowDialog() == true)
                {
                    try
                    {
                        var info = new FileInfo(ofd.FileName);
                        if (info.Length > 2 * 1024 * 1024)
                        {
                            MessageBox.Show("Размер фото не должен превышать 2МБ");
                            return;
                        }

                        SelectedWorker.WorkerPhoto = File.ReadAllBytes(ofd.FileName);
                        db.SaveChanges();
                        SignalChanged("SelectedWorker");

                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            });

            SaveWorker = new CoreCommand(() =>
            {

            });
        }

    }
}
