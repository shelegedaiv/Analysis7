using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Media;
using Analysis7.Model.Entities;
using Analysis7.Model.Observer;
using Analysis7.ViewModel.AbstractViewModel;

namespace Analysis7.ViewModel.ConcreteViewModel
{
    public class EventViewModel : RiskEntityViewModel, IListener
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
                    _modelEvent.Probability.ExpertProbabilities[e.NewStartingIndex].Value = ExpertProbabilities[e.NewStartingIndex];
                };
                OnPropertyChanged(nameof(ExpertProbabilities));
            }
        }

        private ObservableCollection<double> _coefExpertProbabilities;
        public ObservableCollection<double> CoefExpertProbabilities
        {
            get => _coefExpertProbabilities;
            set
            {
                _coefExpertProbabilities = value;
                _coefExpertProbabilities.CollectionChanged += (source, e) =>
                {
                    _modelEvent.Probability.CoefExpertProbabilities[e.NewStartingIndex] = CoefExpertProbabilities[e.NewStartingIndex];
                };
                OnPropertyChanged(nameof(CoefExpertProbabilities));
            }
        }

        private double _coefAverageProbability;
        public double CoefAverageProbability
        {
            get => _coefAverageProbability;
            set
            {
                _coefAverageProbability = value;
                OnPropertyChanged(nameof(CoefAverageProbability));
            }
        }
        public Color GroupColor { get; set; }

        private bool _status;
        public bool Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
                _modelEvent.Status = value;
                _modelEvent.Update();
            }
        }

        private readonly Event _modelEvent;

        public EventViewModel(Event modelEvent, Color color) : base(modelEvent.Name, modelEvent.Description, modelEvent.Probability.AverageProbability.Value)
        {
            _modelEvent = modelEvent;
            Status = _modelEvent.Status;
            GroupColor = color;
            _modelEvent.Probability.AttachListener(this);
            Update();
        }

        public void Update()
        {
<<<<<<< HEAD
            ExpertProbabilities = new ObservableCollection<double>(_modelEvent.Probability.ExpertProbabilities.Select(ev => ev.Value).ToList());
            CoefExpertProbabilities = new ObservableCollection<double>(_modelEvent.Probability.CoefExpertProbabilities.Select(ev => ev).ToList());
            AverageProbability = _modelEvent.Probability.AverageProbability.Value;
            CoefAverageProbability = _modelEvent.Probability.CoefAverageProbability;
=======
            if (Status)
            {
                ExpertProbabilities = new ObservableCollection<double>(_modelEvent.ExpertProbabilities.Select(ev => ev.Value).ToList());
                CoefExpertProbabilities = new ObservableCollection<double>(_modelEvent.CoefExpertProbabilities.Select(ev => ev).ToList());
                AverageProbability = _modelEvent.AverageProbability.Value;
                CoefAverageProbability = _modelEvent.CoefAverageProbability;
            }
            else
            {
                var expertProbabilities = new ObservableCollection<double>();
                var coefExpertProbabilities = new ObservableCollection<double>();
                for (int i = 0; i < 10; i++)
                {
                    expertProbabilities.Add(0);
                    coefExpertProbabilities.Add(0);
                }
                ExpertProbabilities = expertProbabilities;
                CoefExpertProbabilities = coefExpertProbabilities;
                AverageProbability = 0;
                CoefAverageProbability =0;
            }
            
>>>>>>> c3f1630288749a0d785139996f6f7bc855404f48
        }
    }
}