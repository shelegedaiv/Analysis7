using Analysis7.Model.Observer;

namespace Analysis7.Model.Entities
{
    public abstract class RiskEntity:Subject
    {
        public string Name { get; }
        public string Description { get; }
        public Probability AverageProbability { get; set; }
        private bool _status;
        public bool Status
        {
            get => _status;

            set
            {
                _status = value;
                Notify();
            }
        }
        protected RiskEntity(string name, string description, bool status=true)
        {
            Name = name;
            Description = description;
            AverageProbability=new Probability(0);
            Status = status;
        }
    }
}