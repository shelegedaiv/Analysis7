    using System.Collections.Generic;
    using System.Data;
    using System.Dynamic;
using System.Linq;
using Analysis7.Model.Observer;

namespace Analysis7.Model.Entities
{
    public class Event:RiskEntity
    {
<<<<<<< HEAD
        public ProbabilityEntity Probability;
        public PriceEntity Price;

=======
        #region variables
        private readonly List<double> _expertCoefs;
        public List<Probability> ExpertProbabilities { get; set; }
        public List<double> CoefExpertProbabilities { get;}
        public double CoefAverageProbability { get; private set; }
        
        #endregion
>>>>>>> c3f1630288749a0d785139996f6f7bc855404f48
        #region constructors
        public Event(string eventName, string description) : this(eventName, description, new List<double>())
        {
            //todo delete
        }
        
        public Event(string eventName, string description, List<double> expertProbabilities):base(eventName, description)
        {
            Probability = new ProbabilityEntity(expertProbabilities);
            Price = new PriceEntity(expertProbabilities);            
        }
<<<<<<< HEAD
        #endregion
=======

        public void Update()
        {
            for (int i = 0; i < CoefExpertProbabilities.Count; i++)
            {
                CoefExpertProbabilities[i] = ExpertProbabilities[i].Value * _expertCoefs[i];
            }
            AverageProbability = new Probability(ExpertProbabilities.Average(e => e.Value));
            var coefSum = _expertCoefs.Sum();
            if (coefSum.Equals(0))
                CoefAverageProbability = 0;
            else
                CoefAverageProbability = CoefExpertProbabilities.Sum()/_expertCoefs.Sum();
            Notify();
        }
>>>>>>> c3f1630288749a0d785139996f6f7bc855404f48
    }
}