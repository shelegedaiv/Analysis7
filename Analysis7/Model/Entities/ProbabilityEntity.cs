using System;
using System.Collections.Generic;
using System.Linq;
using Analysis7.Model.Observer;

namespace Analysis7.Model.Entities
{
    [Serializable]
    public class ProbabilityEntity:Subject, IListener, IAverageProbability
    {
        protected List<double> ExpertCoefs;
        public bool Status;
        public List<Probability> ExpertProbabilities { get; set; }
        public List<double> CoefExpertProbabilities { get; }
        public double CoefAverageProbability { get; private set; }
        public Probability AverageProbability { get; private set; }
        
        public ProbabilityEntity(List<double> expertProbabilities)
        {
            AverageProbability = new Probability(0);
            ExpertProbabilities = new List<Probability>();
            ExpertCoefs = new List<double>();
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
                    ExpertProbabilities.Add(new Probability(i / 10.0));
                    CoefExpertProbabilities.Add(i / 10.0);
                }

                ExpertCoefs.Add(1);
                ExpertProbabilities[i].AttachListener(this);
            }
            Update();
        }

        public virtual void Update()
        {
            for (int i = 0; i < CoefExpertProbabilities.Count; i++)
            {
                CoefExpertProbabilities[i] = ExpertProbabilities[i].Value * ExpertCoefs[i];
            }
            AverageProbability = new Probability(ExpertProbabilities.Average(e => e.Value));
            CoefAverageProbability = CoefExpertProbabilities.Sum() / ExpertCoefs.Sum();
            Notify();
        }


        public void UpdateCoefficient(int number, double expertCoef)
        {
            ExpertCoefs[number] = expertCoef;
            Update();
        }
    }
}
