using Certification_workers.Core;
using Certification_workers.LocalDB;
using Certification_workers.Views.WorkersFolder;
using ExcelDataReader;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Media3D;

namespace Certification_workers.ViewModels
{
    public class WorkersPageVM : BaseNotify
    {
        CertificationWorkersContext db = new CertificationWorkersContext();

        public List<Worker> ListWorkers { get; set; }
        
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
        
        public CoreCommand AddWorker { get; set; }
        public CoreCommand EditSelectedWorker { get; set; }
        public CoreCommand DownloadFile { get; set; }
        public CoreCommand DeleteSelectedWorker { get; set; }

        public WorkersPageVM(Worker worker)
        {
            ListWorkers = new List<Worker>();
            LoadWorkersFromDB();
            SelectedWorker = worker;


            WorkersCollectionView = CollectionViewSource.GetDefaultView(ListWorkers);
            //WorkersCollectionView.Filter = FilterWorkers;
            WorkersCollectionView.SortDescriptions.Add(new SortDescription(nameof(Worker.Name), ListSortDirection.Ascending));
            
            //commands

            #region

            AddWorker = new CoreCommand(() =>
            {
                EditWorkerWindow editWorkerWindow = new EditWorkerWindow();
                editWorkerWindow.ShowDialog();
            });

            EditSelectedWorker = new CoreCommand(() =>
            {
                EditWorkerWindow editWorkerWindow = new EditWorkerWindow(SelectedWorker);
                editWorkerWindow.ShowDialog();
            });

            DeleteSelectedWorker = new CoreCommand(() =>
            {
                if (MessageBox.Show("Вы точно хотите удалить?", "Вопрос",
                                     MessageBoxButton.YesNo,
                                     MessageBoxImage.Question) == MessageBoxResult.No)
                {

                }
                else
                {
                    //ListWorkers.Remove(SelectedWorker);
                }
            });

            #endregion
        }

        public ICollectionView WorkersCollectionView { get; set; }

        //filters
        #region

        private string _workersNameString = string.Empty;
        public string WorkersNameFilterString
        {
            get
            {
                return _workersNameString;
            }
            set
            {
                _workersNameString = value;
                OnPropertyChanged(nameof(WorkersNameFilterString));
                WorkersCollectionView.Refresh();
            }
        }

        private string _workersLastNameString = string.Empty;
        public string WorkersLastNameFilterString
        {
            get
            {
                return _workersLastNameString;
            }
            set
            {
                _workersLastNameString = value;
                OnPropertyChanged(nameof(WorkersLastNameFilterString));
                WorkersCollectionView.Refresh();
            }
        }

        private string _workersPatronymicString = string.Empty;
        public string WorkersPatronymicFilterString
        {
            get
            {
                return _workersPatronymicString;
            }
            set
            {
                _workersPatronymicString = value;
                OnPropertyChanged(nameof(WorkersPatronymicFilterString));
                WorkersCollectionView.Refresh();
            }
        }

        private string _workersOrganizationString = string.Empty;
        public string WorkersOrganizationFilterString
        {
            get
            {
                return _workersOrganizationString;
            }
            set
            {
                _workersOrganizationString = value;
                OnPropertyChanged(nameof(WorkersOrganizationFilterString));
                WorkersCollectionView.Refresh();
            }
        }

        private string _workersEmailString = string.Empty;
        public string WorkersEmailFilterString
        {
            get
            {
                return _workersEmailString;
            }
            set
            {
                _workersEmailString = value;
                OnPropertyChanged(nameof(WorkersEmailFilterString));
                WorkersCollectionView.Refresh();
            }
        }

        private string _workersPhoneNumberString = string.Empty;
        public string WorkersPhoneNumberFilterString
        {
            get
            {
                return _workersPhoneNumberString;
            }
            set
            {
                _workersPhoneNumberString = value;
                OnPropertyChanged(nameof(WorkersPhoneNumberFilterString));
                WorkersCollectionView.Refresh();
            }
        }

        private string _workersGroupSpecialityString = string.Empty;
        public string WorkersGroupSpecialityFilterString
        {
            get
            {
                return _workersGroupSpecialityString;
            }
            set
            {
                _workersGroupSpecialityString = value;
                OnPropertyChanged(nameof(WorkersGroupSpecialityFilterString));
                WorkersCollectionView.Refresh();
            }
        }

        private string _workersCategoryString = string.Empty;
        public string WorkersCategoryFilterString
        {
            get
            {
                return _workersCategoryString;
            }
            set
            {
                _workersCategoryString = value;
                OnPropertyChanged(nameof(WorkersCategoryFilterString));
                WorkersCollectionView.Refresh();
            }
        }

        private string _workersDateCertifiedString = string.Empty;
        public string WorkersDateCertifiedFilterString
        {
            get
            {
                return _workersDateCertifiedString;
            }
            set
            {
                _workersDateCertifiedString = value;
                OnPropertyChanged(nameof(WorkersDateCertifiedFilterString));
                WorkersCollectionView.Refresh();
            }
        }

        private bool FilterWorkers(object obj)
        {
            /*
            if (obj is Worker worker)
            {
                // string bth = worker.DateCertified.ToString();
                return worker.Name.Contains(_workersNameString, StringComparison.InvariantCultureIgnoreCase) &&
                       worker.LastName.Contains(_workersLastNameString, StringComparison.InvariantCultureIgnoreCase) &&
                       worker.Patronymic.Contains(_workersPatronymicString, StringComparison.InvariantCultureIgnoreCase) &&
                       worker.IdOrganizationNavigation.OrganizationName.Contains(_workersOrganizationString, StringComparison.InvariantCultureIgnoreCase) &&
                       worker.Email.Contains(_workersEmailString, StringComparison.InvariantCultureIgnoreCase) &&
                       worker.GroupSpeciality.Contains(_workersGroupSpecialityString, StringComparison.InvariantCultureIgnoreCase) &&
                       worker.Category.Contains(_workersCategoryString, StringComparison.InvariantCultureIgnoreCase) &&
                       worker.PhoneNumber.Contains(_workersPhoneNumberString, StringComparison.InvariantCultureIgnoreCase);
                
                // worker.IsCertified.Contains(_workersFullNameString, StringComparison.InvariantCultureIgnoreCase) &&
                // bth.Contains(WorkersDateCertifiedFilterString, StringComparison.Ordinal);
            }
            */
            return false;
        }

        #endregion

        private void LoadWorkersFromDB()
        {
            try
            {
                ListWorkers = new List<Worker>(db.Workers.Include(s => s.IdTypeCertifiedNavigation).ToList());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
    }

}
