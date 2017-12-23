using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Analysis7.Model.Observer;

namespace Analysis7.Model.Entities
{
    public class Event:RiskEntity, IListener
    {
        #region variables
        private readonly List<double> _expertCoefs;
        public List<Probability> ExpertProbabilities { get; set; }
        public List<double> CoefExpertProbabilities { get;}
        public double CoefAverageProbability { get; private set; }
        
        #endregion
        #region constructors
        public Event(string eventName, string description) : this(eventName, description, new List<double>())
        {

        }

        public Event(string eventName, string description, List<double> expertProbabilities):base(eventName, description)
        {
            ExpertProbabilities = new List<Probability>();
            _expertCoefs=new List<double>();
            CoefExpertProbabilities = new List<double>();
            for (int i = 0; i < 10; i++)//set 10 probabilities for experts (default values) and coef probabilities = simple probabilities
            {
                if (i < expertProbabilities.Count)
                {
                    ExpertProbabilities.Add(new Probability(expertProbabilities[i]));
                    CoefExpertProbabilities.Add(expertProbabilities[i]);
                    
                }
                else
                {
                    ExpertProbabilities.Add(new Probability(i/10.0));
                    CoefExpertProbabilities.Add(i / 10.0);
                }

                _expertCoefs.Add(1);
                ExpertProbabilities[i].AttachListener(this);
            }
          
            Update();
        }
#endregion
        public void UpdateCoefficient(int number, double expertCoef)
        {
            _expertCoefs[number] = expertCoef;
            Update();
        }

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
    }
}