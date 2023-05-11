using Certification_workers.Core;
using Certification_workers.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Certification_workers.ViewModels.WorkersVMFolder
{
    public class WorkersPageVM : BaseNotify
    {
        public ObservableCollection<Worker> ListWorkers { get; set; }

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


        public ICollectionView WorkersCollectionView { get; set; }

        public CoreCommand AddWorker { get; set; }
        public CoreCommand SaveWorkersInFile { get; set; }
        public CoreCommand DeleteWorker { get; set; }

        public List<DateStruct> DateCertifiedBool { get; set; }
        public WorkersPageVM()
        {
            DateCertifiedBool = new List<DateStruct>
                (
                    new DateStruct[]
                    {
                        new DateStruct{Name = "Сертифицирован", Value=true },
                        new DateStruct{Name = "Не сертифицирован", Value=false }
                    }
                );

            ListWorkers = new ObservableCollection<Worker>
            {
                new Worker
                {
                    IdCode = "EfimovDenDim",
                    Name = "Денис",
                    LastName = "Ефимов",
                    Patronymic = "Дмитриевич",
                    FullName = "Ефимов Денис Дмитриевич",
                    Email = "efimovef@mail.ru",
                    PhoneNumber = "89242478788",
                    Category = "1",
                    GroupSpeciality = "1145",
                    Organization = "ВБМК",
                    IsCertified = true,
                    Id = 1,
                    Description = "Сотрудник",
                    DateCertified = new DateTime(DateTime.Today.Year),
                    StringDateCertified = "11.05.2023"
                }
            };

            WorkersCollectionView = CollectionViewSource.GetDefaultView(ListWorkers);
            WorkersCollectionView.Filter = ShortFilterWorkers; 
            WorkersCollectionView.Filter = LongFilterWorkers;
            WorkersCollectionView.SortDescriptions.Add(new SortDescription(nameof(Worker.Name), ListSortDirection.Ascending));

            //commands
            #region
            AddWorker = new CoreCommand(() =>
            {
                ListWorkers.Add(new Worker
                {
                    IdCode = "нет",
                    Name = "пусто",
                    LastName = "пусто",
                    Patronymic = "пусто",
                    FullName = "пусто",
                    Email = "пусто",
                    PhoneNumber = "не указан",
                    Category = "не указано",
                    GroupSpeciality = "пусто",
                    Organization = "не указано",
                    IsCertified = false,
                    Id = null,
                    Description = "Сотрудник",
                    DateCertified = null,
                    StringDateCertified = "не указано"
                });

            });


            SaveWorkersInFile = new CoreCommand(() =>
            {

            });

            DeleteWorker = new CoreCommand(() =>
            {
               
                if (MessageBox.Show("Вы точно хотите удалить?", "Вопрос",
                                     MessageBoxButton.YesNo,
                                     MessageBoxImage.Question) == MessageBoxResult.No)
                {

                }
                else
                {
                    ListWorkers.Remove(SelectedWorker);
                }
            });

            #endregion

            Task.Run(GetDataWorkersFromFile);
        }

        #region
        private string _workersFullNameString = string.Empty;
        public string WorkersFullNameFilterString
        {
            get
            {
                return _workersFullNameString;
            }
            set
            {
                _workersFullNameString = value;
                OnPropertyChanged(nameof(WorkersFullNameFilterString));
                WorkersCollectionView.Refresh();
            }
        }

        private bool ShortFilterWorkers(object obj)
        {
            if (obj is Worker worker)
            {
                return worker.FullName.Contains(_workersFullNameString, StringComparison.InvariantCultureIgnoreCase);
            }
            return false;
        }
        #endregion

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

        private string _workersIdCodeString = string.Empty;
        public string WorkersIdCodeFilterString
        {
            get
            {
                return _workersIdCodeString;
            }
            set
            {
                _workersIdCodeString = value;
                OnPropertyChanged(nameof(WorkersIdCodeFilterString));
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

        private bool LongFilterWorkers(object obj)
        {
            if (obj is Worker worker)
            {
                string bth = worker.DateCertified.ToString();

                return worker.Name.Contains(_workersNameString, StringComparison.InvariantCultureIgnoreCase) &&
                       worker.LastName.Contains(_workersLastNameString, StringComparison.InvariantCultureIgnoreCase) &&
                       worker.Patronymic.Contains(_workersPatronymicString, StringComparison.InvariantCultureIgnoreCase) &&
                       worker.IdCode.Contains(_workersIdCodeString, StringComparison.InvariantCultureIgnoreCase) &&
                       worker.Organization.Contains(_workersOrganizationString, StringComparison.InvariantCultureIgnoreCase) &&
                       worker.Email.Contains(_workersEmailString, StringComparison.InvariantCultureIgnoreCase) &&
                       worker.GroupSpeciality.Contains(_workersGroupSpecialityString, StringComparison.InvariantCultureIgnoreCase) &&
                       worker.Category.Contains(_workersCategoryString, StringComparison.InvariantCultureIgnoreCase) &&
                       worker.PhoneNumber.Contains(_workersPhoneNumberString, StringComparison.InvariantCultureIgnoreCase) &&
                    // worker.IsCertified.Contains(_workersFullNameString, StringComparison.InvariantCultureIgnoreCase) &&
                       worker.StringDateCertified.Contains(_workersDateCertifiedString, StringComparison.InvariantCultureIgnoreCase);
                    // bth.Contains(WorkersDateCertifiedFilterString, StringComparison.Ordinal);
            }
            return false;
        }

        #endregion

        async Task GetDataWorkersFromFile()
        {
            try
            {

            }
            catch(Exception ex)
            {

            }

            #region mat add
            /*
            var materialsType = connection.MaterialType.ToList();
            var rows = File.ReadAllLines(path);
            for (int i = 0; i<rows.Length; i++)
            {
                var cols = rows[i].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                connection.Material.Add(new Material
                {
                    Title = cols[0],
                    MaterialType = materialsType.First(s => s.Title == cols[1]),
                    Image = cols[2],
                    Cost = decimal.Parse(cols[3]),
                    CountInStock = int.Parse(cols[4]),
                    MinCount = int.Parse(cols[5]),
                    CountInPack = int.Parse(cols[6]),
                    Unit = cols[7]
                });
            }*/
            #endregion
        }


    }
}
