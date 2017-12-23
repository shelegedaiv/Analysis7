using System.Collections.Generic;
using System.Linq;
using Analysis7.Model.Observer;

namespace Analysis7.Model.Entities
{
    public class Expert: Subject,IListener
    {
        private readonly List<ProbabilityEntity> _bindedEvents;
        public int Number { get; set; }
        public double AverageCoefProbability { get; set; }
        private readonly ExpertCoefficient _coefficient;
        public int Coefficient
        {
            get => _coefficient.Value;
            set
            {
                _coefficient.Value = value;
                foreach (var ev in _bindedEvents)
                {
                    ev.UpdateCoefficient(Number,_coefficient.Value);
                }
            }
        }

        public Expert(int number, List<ProbabilityEntity> bindedEvents)
        {
            Number = number;
            _coefficient = new ExpertCoefficient(1);
            _bindedEvents = bindedEvents;
            foreach (var ev in _bindedEvents)
            {
                ev.AttachListener(this);
            }
        }

        public void Update()
        {
            AverageCoefProbability = _bindedEvents.Average(ev => ev.CoefExpertProbabilities[Number]);
        }
    }
}





