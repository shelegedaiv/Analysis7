using System.Collections.Generic;
using System.Linq;
using Analysis7.Model.Observer;

namespace Analysis7.Model.Entities
{
    public class Group:RiskEntity, IListener
    {
        public List<Event> RiskEvents { get; set; }
        public List<Expert> Experts { get; set; }
        public Group(string groupName,string description, List<Event> currentGroupRiskEvents):base(groupName, description)
        {
            RiskEvents = currentGroupRiskEvents;
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
            Update();
        }

        public void Update()
        {
            AverageProbability = new Probability(RiskEvents.Average(e => e.AverageProbability.Value));
            Notify();
        }
    }
}