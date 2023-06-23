using Certification_workers.Core;
using Certification_workers.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Certification_workers.ViewModels
{
    public class MainPageVM : BaseNotify
    {
        public CoreCommand GoToInfoPage { get; set; }
        public MainPageVM()
        {
            GoToInfoPage = new CoreCommand(() =>
            {
                MainWindow.MainNavigate(new InfoPage());
            });
        }
    }
}