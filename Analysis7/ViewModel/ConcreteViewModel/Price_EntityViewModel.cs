using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analysis7.Model.Observer;
using Analysis7.ViewModel.AbstractViewModel;
using System.Collections.ObjectModel;
using System.Windows.Media;
using Analysis7.Model.Entities;

namespace Analysis7.ViewModel.ConcreteViewModel
{
    public class Price_EntityViewModel : EventViewModel
    {
        
        private int _price;
        public int Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

       

       

        public Price_EntityViewModel(Event modelEvent, Color color):base( modelEvent,color)
        {
            Update();
            
            _modelEvent.PriceEntity.AttachListener(this);
        }
        protected virtual void setLinkWithModel()
        {
            ExpertProbabilities.CollectionChanged += (source, e) =>
            {
                _modelEvent.PriceEntity.ExpertProbabilities[e.NewStartingIndex].Value = ExpertProbabilities[e.NewStartingIndex];
            };
            
        }
        public override void Update()
        {

            ExpertProbabilities = new ObservableCollection<double>(_modelEvent.PriceEntity.ExpertProbabilities.Select(ev => ev.Value).ToList());
            CoefExpertProbabilities = new ObservableCollection<double>(_modelEvent.PriceEntity.CoefExpertProbabilities.Select(ev => ev).ToList());
            AverageProbability = _modelEvent.PriceEntity.AverageProbability.Value;
            CoefAverageProbability = _modelEvent.PriceEntity.CoefAverageProbability;
            setLinkWithModel();
        }
    }
}
