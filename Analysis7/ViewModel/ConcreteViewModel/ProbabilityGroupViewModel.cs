using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media;
using Analysis7.Model.Entities;
using Analysis7.Model.Observer;
using Analysis7.ViewModel.AbstractViewModel;

namespace Analysis7.ViewModel.ConcreteViewModel
{
    public class ProbabilityGroupViewModel:RiskEntityViewModel, IListener
    {
        private readonly Group _modelGroup;

        public Color GroupColor { get; }

        private ObservableCollection<int> _expertCoefficients;
        public ObservableCollection<int> ExpertCoefficients
        {
            get => _expertCoefficients;
            set
            {
                _expertCoefficients = value;
                OnPropertyChanged(nameof(ExpertCoefficients));
                _expertCoefficients.CollectionChanged += (source, e) =>
                {
                    _modelGroup.ProbabilityExperts[e.NewStartingIndex].Coefficient = _expertCoefficients[e.NewStartingIndex];
                    Update();
                };
            }
        }

        private int _expertCoefficientsSum;
        public int ExpertCoefficientsSum
        {
            get => _expertCoefficientsSum;
            set
            {
                _expertCoefficientsSum = value;
                OnPropertyChanged(nameof(ExpertCoefficientsSum));
            }
        }

        private ObservableCollection<double> _expertAverageProbabilities;
        public ObservableCollection<double> ExpertAverageProbabilities
        {
            get => _expertAverageProbabilities;
            set
            {
                _expertAverageProbabilities = value;
                OnPropertyChanged(nameof(ExpertAverageProbabilities));
            }
        }

        private double _averageCoefProbability;
        public double AverageCoefProbability
        {
            get => _averageCoefProbability;
            set
            {
                _averageCoefProbability = value;
                OnPropertyChanged(nameof(AverageCoefProbability));
            }
        }

        private int _eventsNumber;
        public int EventsNumber
        {
            get => _eventsNumber;
            private set
            {
                _eventsNumber = value;
                OnPropertyChanged(nameof(EventsNumber));
            }
        }

        private int _sourceNumber;
        public int SourceNumber
        {
            get => _sourceNumber;
            private set
            {
                _sourceNumber = value;
                OnPropertyChanged(nameof(SourceNumber));
            }
        }

        public ProbabilityGroupViewModel(Group modelGroup, Color color):base(modelGroup.Name,modelGroup.Description, modelGroup.AverageProbability.Value)
        {
            GroupColor = color;
            _modelGroup = modelGroup;
            _modelGroup.AttachListenerViewModel(this);
            Update();
        }

        public void Update()
        {
            AverageProbability = _modelGroup.AverageProbability.Value;
            ExpertCoefficients =
                new ObservableCollection<int>(_modelGroup.ProbabilityExperts.Select(exp => exp.Coefficient).ToList());
            ExpertCoefficientsSum = ExpertCoefficients.Sum(exp => exp);
            _modelGroup.ProbabilityExperts.ForEach(ex=>ex.Update());
            ExpertAverageProbabilities=new ObservableCollection<double>(_modelGroup.ProbabilityExperts.Select(ex=>ex.AverageCoefProbability).ToList());
            AverageCoefProbability = ExpertAverageProbabilities.Sum()/ExpertCoefficientsSum;
            SourceNumber = _modelGroup.SourceNumber;
            EventsNumber = _modelGroup.EventsNumber;
        }
    }
}