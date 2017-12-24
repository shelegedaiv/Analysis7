using System;
using Analysis7.Model.Observer;

namespace Analysis7.Model.Entities
{
    [Serializable]
    public abstract class RiskEntity:Subject
    {
        public string Name { get; }
        public string Description { get; }

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
            Status = status;
        }
    }
}