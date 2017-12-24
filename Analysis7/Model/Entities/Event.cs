using System;
using System.Collections.Generic;

namespace Analysis7.Model.Entities
{
    [Serializable]
    public class Event:RiskEntity
    {
        public ProbabilityEntity Probability;
        public PriceEntity Price;

        public Event(string eventName, string description) : this(eventName, description, new List<double>())
        {
        }
        
        public Event(string eventName, string description, List<double> expertProbabilities):base(eventName, description)
        {
            Probability = new ProbabilityEntity(expertProbabilities);
            Price = new PriceEntity(expertProbabilities);           
            Update();
        }

        public void Update()
        {
            Probability.Status = Status;
            Price.Status = Status;
            Probability.Notify();
            Price.Notify();
        }
    }
}