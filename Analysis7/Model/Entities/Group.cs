using System.Collections.Generic;
using System.Linq;
using Analysis7.Model.Observer;

namespace Analysis7.Model.Entities
{
    public class Group:RiskEntity, IListener
    {
        public List<Event> RiskEvents { get; set; }

        public Group(string groupName,string description, List<Event> currentGroupRiskEvents):base(groupName, description)
        {
            RiskEvents = currentGroupRiskEvents;
            foreach (var riskEvent in RiskEvents )
            {
                riskEvent.AttachListener(this);
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