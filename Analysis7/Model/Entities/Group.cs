using System.Collections.Generic;
using System.Linq;
using Analysis7.Model.Observer;

namespace Analysis7.Model.Entities
{
    public class Group:RiskEntity, IListener
    {
        public List<Event> RiskEvents { get; set; }
        public List<Expert> Experts { get; set; }
        public List<Source> RiskSources { get; set; }
        public bool Availability { get; set; }

        public Group(string groupName,string description, List<Event> currentGroupRiskEvents, List<Source> currentGroupRiskSources) :base(groupName, description)
        {
            RiskEvents = currentGroupRiskEvents;
            RiskSources = currentGroupRiskSources;
            foreach (var riskEvent in RiskEvents )
            {
                riskEvent.AttachListener(this);
            }
            Experts=new List<Expert>();
            for (int i = 0; i < 10; i++)
            {
                Experts.Add(new Expert(i, RiskEvents));
            }
            foreach (var expert in Experts  )     {
                expert.AttachListener(this);
            }
            foreach (var riskSource in RiskSources)
            {
                riskSource.AttachListener(this);
            }


            Update();
        }

        public void Update()
        {
            if (RiskEvents.Any(e=>e.Status))
                AverageProbability = new Probability(RiskEvents.Where(e=>e.Status).Average(e => e.AverageProbability.Value));
            else AverageProbability=new Probability(0);
            Notify();
        }

        public void IsGroupAvailable()
        {
            foreach (var item in RiskSources)
            {
                if (item.Status)
                {
                    Availability = true;
                    break;
                }
                Availability = false;
            }

            if (Availability == false)
            {
                Downgrade();
                Update();
            }


        }

        public void Downgrade()
        {
            foreach (var item in RiskEvents)
            {
                foreach (var probability in item.ExpertProbabilities)
                    probability.Value = 0;
            }
        }
    }
}