using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using Analysis7.Converter;
using Analysis7.Model;
using Analysis7.ViewModel.AbstractViewModel;
using Analysis7.ViewModel.ConcreteViewModel;

namespace Analysis7.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private ModelStarter _modelStarter;

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

        private ObservableCollection<ActivityViewModel> _activities;
        public ObservableCollection<ActivityViewModel> Activities
        {
            get => _activities;
            set
            {
                _activities = value;
                OnPropertyChanged(nameof(Activities));
            }
        }

        public MainViewModel(ModelStarter modelStarter)
        {
            Save =new BaseCommand(SaveGame);
            Load = new BaseCommand(LoadGame);
            SetModel(modelStarter);
        }

        private void SetModel(ModelStarter modelStarter)
        {
            ProbabilityGroups = new ObservableCollection<ProbabilityGroupViewModel>();
            PriceGroups = new ObservableCollection<PriceGroupViewModel>();
            AllEvents = new ObservableCollection<EventViewModel>();
            AllPriceEvents = new ObservableCollection<PriceEventViewModel>();
            AllSources = new ObservableCollection<SourceViewModel>();
            Activities = new ObservableCollection<ActivityViewModel>();
            Random r = new Random();
            _modelStarter = modelStarter;
            foreach (var group in modelStarter.Groups)
            {
                var groupColor = Color.FromArgb(100, Convert.ToByte(r.Next(0, 255)), Convert.ToByte(r.Next(0, 255)), Convert.ToByte(r.Next(0, 255)));
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
            foreach (var activity in modelStarter.Activities)
            {
                Activities.Add(new ActivityViewModel(activity));
            }
        }
        
        #region Command
        public ICommand Save { get; set; }
        public ICommand Load { get; set; }

        public void SaveGame(object slotNumber)
        {
            DataSerializer.SerializeData(@"\saving.txt",_modelStarter);
        }

        public void LoadGame(object slotNumber)
        {
            _modelStarter = DataSerializer.DeserializeState(@"\saving.txt");
            SetModel(_modelStarter);
        }
        #endregion
    }
}