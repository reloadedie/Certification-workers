﻿using Certification_workers.Core;
using Certification_workers.LocalDB;
using Certification_workers.Views;
using Certification_workers.Views.WorkersFolder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Certification_workers.ViewModels
{
    public class EditWorkerWindowVM : BaseNotify
    {
        CertificationWorkersContext db = new CertificationWorkersContext();
        public ObservableCollection<Worker> Workers { get; set; }

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
        public CoreCommand CanselCloseClick { get; set; }
        public CoreCommand SaveWorker { get; set; }
        public CoreCommand DeleteWorker { get; set; }

        private bool boolToggleButtonCertified;
        public bool BoolToggleButtonCertified
        {
            get => boolToggleButtonCertified;
            set
            {
                boolToggleButtonCertified = value;
                SignalChanged();
            }
        }

        private Visibility dateCertifiedVisibility = Visibility.Collapsed;
        public Visibility DateCertifiedVisibility
        {
            get => dateCertifiedVisibility;
            set
            {
                dateCertifiedVisibility = value;
                SignalChanged();
            }
        }

        public EditWorkerWindowVM(Worker worker, ToggleButton toggleButtonCertified, Window window)
        {
            if (worker == null)
            {
                worker = new Worker
                {
                    IdTypeCertified = 2
                };
                SelectedWorker = worker;
            }
            SelectedWorker = worker;

            DownloadImagePhotoWorker = new CoreCommand(() =>
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Image files|*.bmp;*.jpg;*.png|All files|*.*";
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
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            });

            SaveWorker = new CoreCommand(() =>
            {
                try
                {
                    if (toggleButtonCertified.IsChecked == true)
                    {
                        SelectedWorker.IdTypeCertified = 1;
                    }
                    else SelectedWorker.IdTypeCertified = 2;

                    if (SelectedWorker.Name == null |
                       SelectedWorker.LastName == null |
                       SelectedWorker.Patronymic == null |
                       SelectedWorker.Email == null |
                       SelectedWorker.PhoneNumber == null |
                       SelectedWorker.OrganizationName == null |
                       SelectedWorker.Category == null |
                       SelectedWorker.GroupSpeciality == null)
                    {
                        MessageBox.Show("Вы не заполнили обязательные поля");
                        return;
                    }

                    if (SelectedWorker.Id == 0)
                    {
                        db.Workers.Add(SelectedWorker);
                    }

                    else
                    {
                        db.Entry(worker).CurrentValues.SetValues(SelectedWorker);
                        db.Workers.Update(SelectedWorker);
                    }
                    db.SaveChanges();
                    window.Close();
                    WorkersPage workersPage = new();
                    MainWindow.MainNavigate(workersPage);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });

            CanselCloseClick = new CoreCommand(() =>
            {
                window.Close();
            });

            DeleteWorker = new CoreCommand(() =>
            {
                if (SelectedWorker.Id == 0)
                {
                    MessageBox.Show("Пока не создано сотрудника, чтобы удалить");
                    return;
                }
                else
                {
                    if (MessageBox.Show("Вы точно хотите удалить?", "Вопрос",
                                   MessageBoxButton.YesNo,
                                   MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        db.Remove(SelectedWorker);
                        db.SaveChanges();
                        window.Close();
                        WorkersPage workersPage = new();
                        MainWindow.MainNavigate(workersPage);
                    }
                    else
                    {
                        return;
                    }
                }

               
            });
        }
    }
}
