using System;
using Analysis7.Model.Observer;

namespace Analysis7.Model.Entities
{
    [Serializable]
    public class ExpertCoefficient:Subject
    {
        private int _coefficient;
        public int Value
        {
            get => _coefficient;
            set
            {
                if (value > 10) _coefficient = 10;
                else if (value <1) _coefficient = 1;
                else _coefficient = value;
                Notify();
            }
        }

        public ExpertCoefficient(int value)
        {
            Value = value;
        }
    }
}