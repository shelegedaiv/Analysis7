using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Windows.Media;
using Analysis7.Model;
using Analysis7.ViewModel.AbstractViewModel;
using Analysis7.ViewModel.ConcreteViewModel;

namespace Analysis7.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<GroupViewModel> _groups;

        public ObservableCollection<GroupViewModel> Groups
        {
            get => _groups;
            set
            {
                _groups = value;
                OnPropertyChanged(nameof(Groups));
            }
            
        }

        private ObservableCollection<EventViewModel> _allEvents;

        public ObservableCollection<EventViewModel> AllEvents
        {
            get => _allEvents;
            set
            {
                _allEvents = value;
                OnPropertyChanged(nameof(AllEvents));
            }
        }
        
        public MainViewModel(ModelStarter modelStarter)
        {
            Groups=new ObservableCollection<GroupViewModel>();
            AllEvents=new ObservableCollection<EventViewModel>();
            Random r=new Random();
            foreach (var group in modelStarter.Groups)
            {
                Groups.Add(new GroupViewModel(group, Color.FromArgb(100, Convert.ToByte(r.Next(0, 255)), Convert.ToByte(r.Next(0,255)), Convert.ToByte(r.Next(0, 255)))));
                foreach (var riskEvent in group.RiskEvents)
                {
                    AllEvents.Add(new EventViewModel(riskEvent, Groups.First(g => g.Name.Equals(group.Name)).GroupColor));
                }
            }
        }

        public ObservableCollection<string> ColumnHeaders { get; }=new ObservableCollection<string>
        {
            "Оцінка експерта 1",
            "Оцінка експерта 2",
            "Оцінка експерта 3",
            "Оцінка експерта 4",
            "Оцінка експерта 5",
            "Оцінка експерта 6",
            "Оцінка експерта 7",
            "Оцінка експерта 8",
            "Оцінка експерта 9",
            "Оцінка експерта 10"
        };
    }
}
//var t1 = new EventViewModel("Затримки у постачанні обладнання, необхідного для підтримки процесу розроблення ПЗ");
//var t2 = new EventViewModel("Затримки у постачанні інструментальних засобів, необхідних для підтримки процесу розроблення ПЗ;");
//var t3 = new EventViewModel("Небажання команди виконавців використовувати інструментальні засоби для підтримки процесу розроблення ПЗ");
//var t4 = new EventViewModel("Формування запитів на більш потужні інструментальні засоби розроблення ПЗ");
//var t5 = new EventViewModel("Відмова команди виконавців від CASE-засобів розроблення ПЗ");
//var t6 = new EventViewModel("Неефективність програмного коду, згенерованого CASE-засобами розроблення ПЗ");
//var t7 = new EventViewModel("Неможливість інтеграції CASE-засобів з іншими інструментальними засобами для підтримки процесу розроблення ПЗ");
//var t8 = new EventViewModel("Недостатня продуктивність баз(и) даних для підтримки процесу розроблення ПЗ");
//var t9 = new EventViewModel("Програмні компоненти, які використовують повторно в ПЗ, мають дефекти та обмежені функціональні можливості");