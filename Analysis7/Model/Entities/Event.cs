    using System.Collections.Generic;
    using System.Data;
    using System.Dynamic;
using System.Linq;
using Analysis7.Model.Observer;

namespace Analysis7.Model.Entities
{
    public class Event:RiskEntity
    {
        public ProbabilityEntity Probability;
        public PriceEntity Price;

        #region constructors
        public Event(string eventName, string description) : this(eventName, description, new List<double>())
        {
            //todo delete
        }
        
        public Event(string eventName, string description, List<double> expertProbabilities):base(eventName, description)
        {
            Probability = new ProbabilityEntity(expertProbabilities);
            Price = new PriceEntity(expertProbabilities);            
        }
        #endregion
    }
}