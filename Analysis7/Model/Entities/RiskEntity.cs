using Analysis7.Model.Observer;

namespace Analysis7.Model.Entities
{
    public abstract class RiskEntity:Subject
    {
        public string Name { get; }
        public string Description { get; }
        public Probability AverageProbability { get; set; }
       
        protected RiskEntity(string name, string description)
        {
            Name = name;
            Description = description;
            AverageProbability=new Probability(0);
        }
    }
}