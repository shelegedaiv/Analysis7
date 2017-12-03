using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Media;
using Analysis7.Model.Entities;
using Analysis7.Model.Observer;
using Analysis7.ViewModel.AbstractViewModel;

namespace Analysis7.ViewModel.ConcreteViewModel
{
    public class EventViewModel:RiskEntityViewModel, IListener
    {
        private ObservableCollection<double> _expertProbabilities;
        public ObservableCollection<double> ExpertProbabilities
        {
            get => _expertProbabilities;
            set
            {
                _expertProbabilities = value;
                _expertProbabilities.CollectionChanged += (source, e) =>
                {
                    _modelEvent.ExpertProbabilities[e.NewStartingIndex].Value = ExpertProbabilities[e.NewStartingIndex];
                };
                OnPropertyChanged(nameof(ExpertProbabilities));
            }
        }
        
        public void ContentCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            
        }
        public Color GroupColor { get; set; }
        private readonly Event _modelEvent;
     
        public EventViewModel(Event modelEvent, Color color):base(modelEvent.Name, modelEvent.Description, modelEvent.AverageProbability.Value)
        {
            _modelEvent = modelEvent;
            GroupColor = color;
            _modelEvent.AttachListener(this);
            Update();
        }
        
        public void Update()
        {
            ExpertProbabilities=new ObservableCollection<double>(_modelEvent.ExpertProbabilities.Select(ev=>ev.Value).ToList());
            AverageProbability = _modelEvent.AverageProbability.Value;
        }
    }
}