using Analysis7.Model.Observer;

namespace Analysis7.Model.Entities
{
    public class Probability:Subject
    {
        private double _probability;

        public double Value
        {
            get =>_probability;
            set
            {
                if (value > 1) _probability = 1;
                else if (value < 0) _probability = 0;
                else _probability = value;
                Notify();
            }
        }

        public Probability(double value)
        {
            Value = value;
        }
    }
}