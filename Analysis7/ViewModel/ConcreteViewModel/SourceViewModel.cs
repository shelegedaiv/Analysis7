using Analysis7.Model.Entities;
using Analysis7.Model.Observer;
using Analysis7.ViewModel.AbstractViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Analysis7.ViewModel.ConcreteViewModel
{
    public class SourceViewModel: RiskEntityViewModel, IListener
    {
        private bool _status;
        public bool Status
        {
            get => _status;

            set
            {
                _status = value;
                OnPropertyChanged(nameof(_status));
                _modelSource.Status = Status;
            }
        }

        public Color GroupColor { get; set; }
        private readonly Source _modelSource;

        public SourceViewModel(Source modelSource, Color color):base(modelSource.Name, modelSource.Description, modelSource.AverageProbability.Value)
        {
            _modelSource = modelSource;
            GroupColor = color;
            _modelSource.AttachListener(this);
            Update();
        }

        public void Update()
        {
            _status = _modelSource.Status;
            OnPropertyChanged(nameof(Status));
        }
    }
}
