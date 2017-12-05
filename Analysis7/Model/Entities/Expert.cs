using System.Collections.Generic;
using System.Linq;
using Analysis7.Model.Observer;

namespace Analysis7.Model.Entities
{
    public class Expert: Subject,IListener
    {
        private readonly List<Event> _bindedEvents;

        public Expert(int number, List<Event> bindedEvents)
        {
            Number = number;
            Coefficient = new ExpertCoefficient(1);
            _bindedEvents = bindedEvents;
            foreach (var ev in _bindedEvents)
            {
                ev.AttachListener(this);
            }
        }

        public int Number { get; set; }
        public Probability AverageProbability { get; set; }
        public ExpertCoefficient Coefficient { get; set; }
        

        public void Update()
        {
            AverageProbability = new Probability(_bindedEvents.Average(ev => ev.ExpertProbabilities[Number].Value));
        }
    }
}





