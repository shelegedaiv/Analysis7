using System;
using System.Collections.Generic;
using System.Linq;

namespace Analysis7.Model.Entities
{
    [Serializable]
    public class PriceEntity : ProbabilityEntity, IPriceInterface
    {
        private double _startPrice;
        public double StartPrice
        {
            get => _startPrice;
            set
            {
                _startPrice = value < 0 ? 0 : value;
                Notify();
            }
        }

        public double AdditionalPrice
        {
            get =>CoefExpertProbabilities.Sum() * _startPrice / ExpertCoefs.Sum() ;
        }

        public double FinalPrice
        {
            get => AdditionalPrice + _startPrice;
        }

        public PriceEntity( List<double> expertProbabilities):base(expertProbabilities)
        {
            StartPrice = 12;
        }
    }
}
