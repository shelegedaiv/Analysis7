using System.Windows.Media;
using Analysis7.Model.Entities;
using Analysis7.Model.Observer;
using Analysis7.ViewModel.AbstractViewModel;

namespace Analysis7.ViewModel.ConcreteViewModel
{
    public class GroupViewModel:RiskEntityViewModel, IListener
    {
        private readonly Group _modelGroup;
        public Color GroupColor { get; }
        public GroupViewModel(Group modelGroup, Color color):base(modelGroup.Name,modelGroup.Description, modelGroup.AverageProbability.Value)
        {
            _modelGroup = modelGroup;
            _modelGroup.AttachListener(this);
            GroupColor = color;

            
        }

        public void Update()
        {
            AverageProbability = _modelGroup.AverageProbability.Value;
        }
    }
}