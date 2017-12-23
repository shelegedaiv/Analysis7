using Analysis7.Model.Observer;

namespace Analysis7.Model.Entities
{
    public abstract class RiskEntity:Subject
    {
        public string Name { get; }
        public string Description { get; }
<<<<<<< HEAD
        
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
=======
        public Probability AverageProbability { get; set; }
        public bool Status { get; set; }
       
>>>>>>> c3f1630288749a0d785139996f6f7bc855404f48
        protected RiskEntity(string name, string description, bool status=true)
        {
            Name = name;
            Description = description;
            Status = status;
        }
    }
}