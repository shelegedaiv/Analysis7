using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analysis7.Model.Observer;

namespace Analysis7.Model.Entities
{
    public class PriceEntity : ProbabilityEntity
    {
        private int _price;
        public int Price
        {
            get => _price;

            set => _price = (value < 0) ? 0 : value;
        }
        #region constructors
        public PriceEntity( List<double> expertProbabilities):base(expertProbabilities)
        {
            Price = 0;
        }
        #endregion
        //todo add prices   
        public override void Update()
        {
            base.Update();
            
        }

    }
}
