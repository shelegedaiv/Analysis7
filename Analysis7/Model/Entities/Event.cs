using System.Collections.Generic;
using System.Linq;
using Analysis7.Model.Observer;

namespace Analysis7.Model.Entities
{
    public class Event:RiskEntity, IListener
    {
        private List<ExpertCoefficient> _expertCoefs;
        public List<Probability> ExpertProbabilities { get; set; }
        
        public Event(string eventName, string description) : this(eventName, description, new List<double>())
        {

        }

        public Event(string eventName, string description, List<double> expertProbabilities):base(eventName, description)
        {
            SetExpertCoefficients(new List<ExpertCoefficient>());
            ExpertProbabilities = new List<Probability>();
            foreach (var mark in expertProbabilities )
            {
                ExpertProbabilities.Add(new Probability(mark));

            }
            while (ExpertProbabilities.Count < 10)
            {
                ExpertProbabilities.Add(new Probability((ExpertProbabilities.Count+1)/10.0));
            }
            foreach (var mark in ExpertProbabilities )
            {
                mark.AttachListener(this);
            }
            Update();
        }

        public void SetExpertCoefficients(List<ExpertCoefficient> expertCoefs)
        {
            _expertCoefs = expertCoefs;
        }
        public void Update()
        {
            AverageProbability = ExpertProbabilities.Count == 0 ? new Probability(0) : new Probability(ExpertProbabilities.Average(e => e.Value));
            Notify();
        }
    }
}