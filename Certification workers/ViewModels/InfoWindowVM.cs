using Certification_workers.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Certification_workers.ViewModels
{
    public class InfoWindowVM : BaseNotify
    {
        private string helpedList;
        public string HelpedList
        {
            get => helpedList;
            set
            {
                helpedList = value;
                SignalChanged();
            }
        }

        private ComboBoxItem selectedTag;
        public ComboBoxItem SelectedTag
        {
            get => selectedTag;
            set
            {
                selectedTag = value;
                ChangeText(selectedTag.Tag as string);
            }
        }

        public string TagScreenPath { get; set; }
        private readonly string path = "C:\\Users\\kirya\\source\\repos\\Certification workers\\Certification workers\\Resources\\InfoScreens\\Test1.png";

        public InfoWindowVM()
        {
                
        }


        private void ChangeText(string index)
        {
            switch (index)
            {
                //Что это за программа? Что она делает?
                case "1" :
                    HelpedList = "";
                    //TagScreenPath = Environment.CurrentDirectory + "/Resources/InfoScreens/Test1.png";
                    TagScreenPath = path;
                    break;

                //Возможности программы?
                case "2":
                    HelpedList = "";
                    break;

                //Как воспользоваться функциями данной программы?
                case "3":
                    HelpedList = "";
                    break;

                //Как создать сотрудника?
                case "4":
                    HelpedList = "";
                    break;

                //Как импортировать данные?
                case "5":
                    HelpedList = "";
                    break;

                //Как сменить стиль программы?
                case "6":
                    HelpedList = "";
                    break;

                //Основной цикл работы программы?
                case "7":
                    HelpedList = "";
                    break;

                //Не подходит стиль оформления программы?
                case "8":
                    HelpedList = "";
                    break;

                //Программа сбоит, даёт ошибки. Что делать?
                case "9":
                    HelpedList = "";
                    break;

                //Как связаться с разработчиком?
                case "10":
                    HelpedList = "";
                    break;
            }
        }

    }
}
