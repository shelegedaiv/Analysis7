using System;
using System.Collections.Generic;
using System.Linq;
using Analysis7.Model.Observer;

namespace Analysis7.Model.Entities
{
    [Serializable]
    public class Group:RiskEntity, IListener, IAverageProbability, IPriceInterface
    {
        public List<Event> RiskEvents { get; set; }
        public List<Expert> ProbabilityExperts { get; set; }
        public List<Expert> PriceExperts { get; set; }
        public List<Source> RiskSources { get; set; }
        public Probability AverageProbability {get; set;}
        public Probability PriceAverageProbability { get; set; }

        public int SourceNumber
        {
            get => RiskSources.Count(e => e.Status);
        }

        public int EventsNumber
        {
            get => RiskEvents.Count(e=>e.Status);
        }

        public Group(string groupName,string description, List<Event> currentGroupRiskEvents, List<Source> currentGroupRiskSources) :base(groupName, description)
        {
            RiskEvents = currentGroupRiskEvents;
            RiskSources = currentGroupRiskSources;
            foreach (var riskEvent in RiskEvents)
            {
                riskEvent.AttachListener(this);
                riskEvent.Price.AttachListener(this);
                riskEvent.Probability.AttachListener(this);
            }
            ProbabilityExperts=new List<Expert>();//todo return
            for (int i = 0; i < 10; i++)
            {
                ProbabilityExperts.Add(new Expert(i,  RiskEvents.Select(e => e.Probability).ToList()));
            }
            PriceExperts = new List<Expert>();
            for (int i = 0; i < 10; i++)
            {
                PriceExperts.Add(new Expert(i, RiskEvents.Select(e=> (ProbabilityEntity)e.Price).ToList()));
            }
            foreach (var expert in ProbabilityExperts  )     {
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
            if (RiskEvents.Any(e => e.Status))
            {
                AverageProbability = new Probability(RiskEvents.Where(e => e.Status)
                    .Average(e => e.Probability.AverageProbability.Value));
                PriceAverageProbability =
                    new Probability(RiskEvents.Where(e => e.Status).Average(e => e.Price.AverageProbability.Value));
                StartPrice=RiskEvents.Where(e=>e.Status).Sum(e=>e.Price.StartPrice);
                AdditionalPrice = RiskEvents.Where(e => e.Status).Sum(e => e.Price.AdditionalPrice);
                FinalPrice = RiskEvents.Where(e => e.Status).Sum(e => e.Price.FinalPrice);
            }
            else
            {
                AverageProbability=new Probability(0);
                PriceAverageProbability=new Probability(0);
            }

            Notify();
        }

        public double StartPrice { get; set; }
        public double AdditionalPrice { get; set; }
        public double FinalPrice { get; set; }

    }
}