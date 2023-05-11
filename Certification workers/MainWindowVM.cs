using Certification_workers.Core;
using Certification_workers.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Certification_workers
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        void SignalChanged([CallerMemberName] string prop = null) =>
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public event PropertyChangedEventHandler? PropertyChanged;

        //public Page CurrentPage { get; set; }
        //CurrentPage = new WorkersPage(); SignalChanged("CurrentPage");

        public CoreCommand MainPageCommand { get; set; }
        public CoreCommand GoToWorkersPage { get; set; }
        public CoreCommand GoToSearchPage { get; set; }
        public CoreCommand GoToDataPage { get; set; }
        public CoreCommand GoToInfoPage { get; set; }

        public CoreCommand GoToSettingsPage { get; set; }

        public MainWindowVM(Window window)
        {
            MainPageCommand = new CoreCommand(() =>
            {
                MainWindow.MainNavigate(new MainPage());
            });

            GoToWorkersPage = new CoreCommand(() => 
            {
                MainWindow.MainNavigate(new WorkersPage());
            });

            GoToSearchPage = new CoreCommand(() => 
            {
                //MainWindow.MainNavigate(new SearchPage());
            });

            GoToDataPage = new CoreCommand(() => 
            {
                MainWindow.MainNavigate(new DataPage());
            });

            GoToInfoPage = new CoreCommand(() =>
            {
                MainWindow.MainNavigate(new InfoPage());
            });

            GoToSettingsPage = new CoreCommand(() => 
            {
                MainWindow.MainNavigate(new SettingsPage());
            });

        }
        
    }
}
