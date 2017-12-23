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
        private ObservableCollection<ProbabilityGroupViewModel> _probabilityGroups;

        public ObservableCollection<ProbabilityGroupViewModel> ProbabilityGroups
        {
            get => _probabilityGroups;
            set
            {
                _probabilityGroups = value;
                OnPropertyChanged(nameof(ProbabilityGroups));
            }
            
        }
        private ObservableCollection<PriceGroupViewModel> _priceGroups;

        public ObservableCollection<PriceGroupViewModel> PriceGroups
        {
            get => _priceGroups;
            set
            {
                _priceGroups = value;
                OnPropertyChanged(nameof(PriceGroups));
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
        private ObservableCollection<PriceEventViewModel> _allPriceEvents;

        public ObservableCollection<PriceEventViewModel> AllPriceEvents
        {
            get => _allPriceEvents;
            set
            {
                _allPriceEvents = value;
                OnPropertyChanged(nameof(AllPriceEvents));
            }
        }

        private ObservableCollection<SourceViewModel> _allSources;

        public ObservableCollection<SourceViewModel> AllSources
        {
            get => _allSources;
            set
            {
                _allSources = value;
                OnPropertyChanged(nameof(AllSources));
            }
        }
        public MainViewModel(ModelStarter modelStarter)
        {
            ProbabilityGroups=new ObservableCollection<ProbabilityGroupViewModel>();
            PriceGroups = new ObservableCollection<PriceGroupViewModel>();
            AllEvents =new ObservableCollection<EventViewModel>();
            AllPriceEvents = new ObservableCollection<PriceEventViewModel>();
            AllSources =new ObservableCollection<SourceViewModel>();
            Random r=new Random();
            foreach (var group in modelStarter.Groups)
            {
                var groupColor= Color.FromArgb(100, Convert.ToByte(r.Next(0, 255)), Convert.ToByte(r.Next(0, 255)), Convert.ToByte(r.Next(0, 255)));
                ProbabilityGroups.Add(new ProbabilityGroupViewModel(group, groupColor));
                PriceGroups.Add(new PriceGroupViewModel(group, groupColor));
                foreach (var riskEvent in group.RiskEvents)
                {
                    AllEvents.Add(new EventViewModel(riskEvent, PriceGroups.First(g => g.Name.Equals(group.Name)).GroupColor));
                    AllPriceEvents.Add(new PriceEventViewModel(riskEvent, PriceGroups.First(g => g.Name.Equals(group.Name)).GroupColor));

                }
                foreach (var source in group.RiskSources)
                {
                    AllSources.Add(new SourceViewModel(source, PriceGroups.First(g => g.Name.Equals(group.Name)).GroupColor));
                }
            }
        }
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