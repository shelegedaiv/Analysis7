using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analysis7.Model.Observer;

namespace Analysis7.Model.Entities
{
    public class PriceEntity : ProbabilityEntity, IPriceInterface
    {

        private double _startPrice;

        public double StartPrice
        {
            get => _startPrice;
            set
            {
                _startPrice = (value < 0) ? 0 : value;
                Notify();
            }
        }

        public double AdditionalPrice
        {
            get =>CoefExpertProbabilities.Sum() * _startPrice / _expertCoefs.Sum() ;
        }

        public double FinalPrice
        {
            get => AdditionalPrice + _startPrice;
        }
        #region constructors

        public PriceEntity( List<double> expertProbabilities):base(expertProbabilities)
        {
            StartPrice = 12;
        }
        #endregion
    }
}
