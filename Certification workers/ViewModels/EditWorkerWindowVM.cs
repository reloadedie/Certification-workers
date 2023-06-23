using Certification_workers.Core;
using Certification_workers.LocalDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certification_workers.ViewModels
{
    public class EditWorkerWindowVM : BaseNotify
    {
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

            });
        }
        
    }
}
