using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Analysis7.Model.Observer;

namespace Analysis7.Model.Entities
{
    public class Event:RiskEntity, IListener
    {
        #region variables
        //todo delete
        // private List<IListener> _groupExperts;
        private List<double> _expertCoefs;
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
            AverageProbability = new Probability(ExpertProbabilities.Average(e => e.Value)); //ExpertProbabilities.Count == 0 ? new Probability(0) : new Probability(ExpertProbabilities.Average(e => e.Value));
            CoefAverageProbability = CoefExpertProbabilities.Average(); //CoefExpertProbabilities.Count == 0 ? 0 : CoefExpertProbabilities.Average();
            Notify();
        }
        //todo delete
        //public void AttachExpert(IListener expert)
        //{
        //    if (_groupExperts is null) _groupExperts=new List<IListener>();
        //    _groupExperts.Add(expert);
        //}

        //public void NotifyExpert()
        //{
        //    foreach (var expert in _groupExperts)     {
        //        expert.Update();
        //    }
        //}
    }
}