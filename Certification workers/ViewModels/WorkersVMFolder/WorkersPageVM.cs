using Certification_workers.Core;
using Certification_workers.Models;
using Certification_workers.Views.WorkersFolder;
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
        public CoreCommand EditWorker { get; set; }
        public CoreCommand DeleteWorker { get; set; }

        public WorkersPageVM()
        {
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
                    Group = "1145",
                    Organization = "ВБМК",
                    YearAdmission = 2022,
                    YearEnding = 2023,
                    IsCertified = true,
                    Id = 1,
                    IdGroup = 2,
                    Description = "Сотрудник",
                    DateAdmission = new DateTime(DateTime.Today.Year),
                    DateEnding = new DateTime(DateTime.Now.Year)
                }
            };

            WorkersCollectionView = CollectionViewSource.GetDefaultView(ListWorkers);
            WorkersCollectionView.Filter = FilterWorkers;
            WorkersCollectionView.SortDescriptions.Add(new SortDescription(nameof(Worker.Name), ListSortDirection.Ascending));

            //commands
            #region
            AddWorker = new CoreCommand(() =>
            {
                WorkersWindow workersWindow = new WorkersWindow();
                workersWindow.Show();
            });

            EditWorker = new CoreCommand(() =>
            {
                // WorkersWindow workersWindow = new WorkersWindow(SelectedWorker);
                // workersWindow.Show();
            });

            DeleteWorker = new CoreCommand(() =>
            {
                MessageBox.Show("Вы точно хотите удалить?");
                // yes or not message?

            });

            #endregion

            Task.Run(GetDataWorkersFromFile);
        }

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

        private bool FilterWorkers(object obj)
        {
            if (obj is Worker worker)
            {
                return worker.Name.Contains(WorkersNameFilterString, StringComparison.InvariantCultureIgnoreCase);
            }
            return false;
        }

        async Task GetDataWorkersFromFile()
        {
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
