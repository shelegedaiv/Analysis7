using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media;
using Analysis7.Model.Entities;
using Analysis7.Model.Observer;
using Analysis7.ViewModel.AbstractViewModel;

namespace Analysis7.ViewModel.ConcreteViewModel
{
    public class GroupViewModel:RiskEntityViewModel, IListener
    {
        private readonly Group _modelGroup;
        private ObservableCollection<int> _expertCoefficients;
        private ObservableCollection<int> _averageExpertCoefficients;
        private int _expertCoefficientsSum;

        public GroupViewModel(Group modelGroup, Color color):base(modelGroup.Name,modelGroup.Description, modelGroup.AverageProbability.Value)
        {
            _modelGroup = modelGroup;
            _modelGroup.AttachListener(this);
            GroupColor = color;
            Update();
            
        }
        public Color GroupColor { get; }

        public ObservableCollection<int> ExpertCoefficients
        {
            get => _expertCoefficients;
            set
            {
                _expertCoefficients = value;
                OnPropertyChanged(nameof(ExpertCoefficients));
                _expertCoefficients.CollectionChanged += (source, e) =>
                {
                    _modelGroup.Experts[e.NewStartingIndex].Coefficient.Value = _expertCoefficients[e.NewStartingIndex];
                    Update();
                };
            }
        }

        private ObservableCollection<int> AverageExpertCoefficients
        {
            get => _averageExpertCoefficients;
            set
            {
                _averageExpertCoefficients = value;
                OnPropertyChanged(nameof(AverageExpertCoefficients));
            }
        }
        public int ExpertCoefficientsSum
        {
            get => _expertCoefficientsSum;
            set
            {
                _expertCoefficientsSum = value;
                OnPropertyChanged(nameof(ExpertCoefficientsSum));
            }
        }
        public void Update()
        {
            AverageProbability = _modelGroup.AverageProbability.Value;
            ExpertCoefficients =
                new ObservableCollection<int>(_modelGroup.Experts.Select(exp => exp.Coefficient.Value).ToList());
            ExpertCoefficientsSum = ExpertCoefficients.Sum(exp => exp);
        }


    }
}