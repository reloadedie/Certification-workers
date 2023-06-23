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

        public InfoWindowVM()
        {
                
        }


        private void ChangeText(string index)
        {
            switch (index)
            {
                //Что это за программа? Что она делает?
                case "1" :
                    
                    break;

                //Возможности программы?
                case "2":
                    
                    break;

                //Как воспользоваться функциями данной программы?
                case "3":
                    
                    break;

                //Как создать сотрудника?
                case "4":
                    
                    break;

                //Как импортировать данные?
                case "5":
                    
                    break;

                //Как сменить стиль программы?
                case "6":
                    
                    break;

                //Основной цикл работы программы?
                case "7":
                    
                    break;

                //Не подходит стиль оформления программы?
                case "8":
                    
                    break;

                //Программа сбоит, даёт ошибки. Что делать?
                case "9":
                    
                    break;

                //Как связаться с разработчиком?
                case "10":
                    
                    break;
            }
        }

    }
}
