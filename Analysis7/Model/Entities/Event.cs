using System;
using System.Collections.Generic;


namespace Analysis7.Model.Entities
{
    [Serializable]
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

        public void Update()//todo check 
        {
            Probability.Status = Status;
            Price.Status = Status;
            Notify();
        }
    }
}