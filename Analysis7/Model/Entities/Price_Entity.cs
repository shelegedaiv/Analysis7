using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analysis7.Model.Observer;

namespace Analysis7.Model.Entities
{
    public class Price_Entity : Subject, IListener
    {
        #region variables
       
        
        private List<double> _expertCoefs;
        public List<Probability> ExpertProbabilities { get; set; }
        public List<double> CoefExpertProbabilities { get; }
        public double CoefAverageProbability { get; private set; }
        //Andrii
        public Probability AverageProbability { get; set; }

        private int _price;
        public int Price
        {
            get => _price;

            set
            {
                _price = (value < 0) ? 0 : value;
               // Notify();
            }

        }


        #endregion
        #region constructors
        //public Price_Entity(string eventName, string description) : this(eventName, description, new List<double>())
        //{

        //}

        public Price_Entity( List<double> expertProbabilities)//:base(eventName, description)
        {
            AverageProbability = new Probability(0);
            ExpertProbabilities = new List<Probability>();
            _expertCoefs = new List<double>();
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
                    ExpertProbabilities.Add(new Probability(1-i / 10.0));
                    CoefExpertProbabilities.Add(1-i / 10.0);
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
            CoefAverageProbability = CoefExpertProbabilities.Sum() / _expertCoefs.Sum();
            Notify();
        }

    }
}
