using Certification_workers.Core;
using Certification_workers.LocalDB;
using Certification_workers.Views;
using Certification_workers.Views.WorkersFolder;
using ExcelDataReader;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        public List<Worker> FilteredCertifiedListWorkers;

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

        public CoreCommand WorkerSortUpName { get; set; }
        public CoreCommand WorkerSortDownName { get; set; }

        public CoreCommand WorkerSortUpLastName { get; set; }
        public CoreCommand WorkerSortDownLastName { get; set; }

        public CoreCommand WorkerSortUpPatronymic { get; set; }
        public CoreCommand WorkerSortDownPatronymic { get; set; }

        public CoreCommand WorkerSortUpGroupSpeciality { get; set; }
        public CoreCommand WorkerSortDownGroupSpeciality { get; set; }

        public CoreCommand WorkerSortUpDateCertified { get; set; }
        public CoreCommand WorkerSortDownDateCertified { get; set; }

        public CoreCommand WorkerSortUpTypeCertified { get; set; }
        public CoreCommand WorkerSortDownTypeCertified { get; set; }

        public CoreCommand CanselSortingList { get; set; }

        public WorkersPageVM(Worker worker)
        {
            ListWorkers = new List<Worker>();
            LoadWorkersFromDB();
            SelectedWorker = worker;

            WorkersCollectionView = CollectionViewSource.GetDefaultView(ListWorkers);
            WorkersCollectionView.Filter = FilterWorkers;

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
                                     MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    db.Remove(SelectedWorker);
                    db.SaveChanges();
                    LoadWorkers();
                    WorkersPage workersPage = new();
                    MainWindow.MainNavigate(workersPage);
                }
                else
                {
                    return;
                }
            });

            // Dynamic sorting
            #region
            WorkerSortUpName = new CoreCommand(() =>
            {
                WorkersCollectionView.SortDescriptions.Clear();
                WorkersCollectionView.SortDescriptions.Add(new SortDescription(nameof(Worker.Name), ListSortDirection.Ascending));
            });

            WorkerSortDownName = new CoreCommand(() =>
            {
                WorkersCollectionView.SortDescriptions.Clear();
                WorkersCollectionView.SortDescriptions.Add(new SortDescription(nameof(Worker.Name), ListSortDirection.Descending));
            });

            WorkerSortUpLastName = new CoreCommand(() =>
            {
                WorkersCollectionView.SortDescriptions.Clear();
                WorkersCollectionView.SortDescriptions.Add(new SortDescription(nameof(Worker.LastName), ListSortDirection.Ascending));
            });

            WorkerSortDownLastName = new CoreCommand(() =>
            {
                WorkersCollectionView.SortDescriptions.Clear();
                WorkersCollectionView.SortDescriptions.Add(new SortDescription(nameof(Worker.LastName), ListSortDirection.Descending));
            });

            WorkerSortUpPatronymic = new CoreCommand(() =>
            {
                WorkersCollectionView.SortDescriptions.Clear();
                WorkersCollectionView.SortDescriptions.Add(new SortDescription(nameof(Worker.Patronymic), ListSortDirection.Ascending));
            });

            WorkerSortDownPatronymic = new CoreCommand(() =>
            {
                WorkersCollectionView.SortDescriptions.Clear();
                WorkersCollectionView.SortDescriptions.Add(new SortDescription(nameof(Worker.Patronymic), ListSortDirection.Descending));
            });

            WorkerSortUpGroupSpeciality = new CoreCommand(() =>
            {
                WorkersCollectionView.SortDescriptions.Clear();
                WorkersCollectionView.SortDescriptions.Add(new SortDescription(nameof(Worker.GroupSpeciality), ListSortDirection.Ascending));
            });

            WorkerSortDownGroupSpeciality = new CoreCommand(() =>
            {
                WorkersCollectionView.SortDescriptions.Clear();
                WorkersCollectionView.SortDescriptions.Add(new SortDescription(nameof(Worker.GroupSpeciality), ListSortDirection.Descending));
            });

            WorkerSortUpDateCertified = new CoreCommand(() =>
            {
                WorkersCollectionView.SortDescriptions.Clear();
                WorkersCollectionView.SortDescriptions.Add(new SortDescription(nameof(Worker.DateCertified), ListSortDirection.Descending));
            });

            WorkerSortDownDateCertified = new CoreCommand(() =>
            {
                WorkersCollectionView.SortDescriptions.Clear();
                WorkersCollectionView.SortDescriptions.Add(new SortDescription(nameof(Worker.DateCertified), ListSortDirection.Ascending));
            });

            WorkerSortUpTypeCertified = new CoreCommand(() =>
            {
                WorkersCollectionView.SortDescriptions.Clear();
                WorkersCollectionView.SortDescriptions.Add(new SortDescription(nameof(Worker.IdTypeCertified), ListSortDirection.Ascending));
            });

            WorkerSortDownTypeCertified = new CoreCommand(() =>
            {
                WorkersCollectionView.SortDescriptions.Clear();
                WorkersCollectionView.SortDescriptions.Add(new SortDescription(nameof(Worker.IdTypeCertified), ListSortDirection.Descending));
            });

            CanselSortingList = new CoreCommand(() =>
            {
                WorkersCollectionView.SortDescriptions.Clear();
            });
            #endregion

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
            if (obj is Worker worker)
            {
                string datecert = worker.DateCertified.Value.ToShortDateString();
                return worker.Name.Contains(_workersNameString, StringComparison.InvariantCultureIgnoreCase) &&
                       worker.LastName.Contains(_workersLastNameString, StringComparison.InvariantCultureIgnoreCase) &&
                       worker.Patronymic.Contains(_workersPatronymicString, StringComparison.InvariantCultureIgnoreCase) &&
                       worker.OrganizationName.Contains(_workersOrganizationString, StringComparison.InvariantCultureIgnoreCase) &&
                       worker.Email.Contains(_workersEmailString, StringComparison.InvariantCultureIgnoreCase) &&
                       worker.GroupSpeciality.Contains(_workersGroupSpecialityString, StringComparison.InvariantCultureIgnoreCase) &&
                       worker.Category.Contains(_workersCategoryString, StringComparison.InvariantCultureIgnoreCase) &&
                       worker.PhoneNumber.Contains(_workersPhoneNumberString, StringComparison.InvariantCultureIgnoreCase) &&
                       worker.IdTypeCertifiedNavigation.TypeName.Contains(_workersCategoryString, StringComparison.InvariantCultureIgnoreCase)&&
                       datecert.Contains(WorkersDateCertifiedFilterString, StringComparison.Ordinal);
            }
            
            return false;
        }

        #endregion

        public ObservableCollection<TypeCertified> CertifiedTypes { get; set; }
        private List<TypeCertified> allTypeCertifiedList;

        private TypeCertified selectedTypeCertified;
        public TypeCertified SelectedTypeCertified
        {
            get => selectedTypeCertified;
            set
            {
                selectedTypeCertified = value;
                FilterCertifiedType();
                SignalChanged();
            }
        }

        private void FilterCertifiedType()
        {
            if (selectedWorker?.IdTypeCertified == 0)
            {
                LoadWorkersFromDB();
            }
            var filteredWorkers = FilteredCertifiedListWorkers
                    .Where(x => x.IdTypeCertified == SelectedWorker.IdTypeCertified);
            ListWorkers = new List<Worker>(filteredWorkers);
            SignalChanged("ListWorkers");
        }

        private void LoadWorkersFromDB()
        {
            try
            {
                ListWorkers = new List<Worker>(db.Workers.Include(s => s.IdTypeCertifiedNavigation).ToList());
                SignalChanged("Workers");

                allTypeCertifiedList = db.TypeCertifieds.ToList();
                allTypeCertifiedList.Insert(0, new TypeCertified());
                CertifiedTypes = new ObservableCollection<TypeCertified>(allTypeCertifiedList);
                SignalChanged("CertifiedTypes");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void LoadWorkers()
        {
            ListWorkers = new List<Worker>(db.Workers);
            SignalChanged("Workers");
        }
    }

}
