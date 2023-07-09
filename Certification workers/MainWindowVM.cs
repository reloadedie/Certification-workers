using Certification_workers.Core;
using Certification_workers.Views;
using System.Windows;

namespace Certification_workers
{
    public class MainWindowVM : BaseNotify
    {
        WorkersPage workersPage = new();

        public CoreCommand MainPageCommand { get; set; }
        public CoreCommand GoToWorkersPage { get; set; }
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
                WorkersPage workersPageUpd = new();
                MainWindow.MainNavigate(workersPageUpd);
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
