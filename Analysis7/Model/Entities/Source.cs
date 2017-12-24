using System;

namespace Analysis7.Model.Entities
{
    [Serializable]
    public class Source : RiskEntity
    {
        public Source(string name, string description) : base(name, description)
        {
            Status = true;
        }
    }
}