using Analysis7.ViewModel.AbstractViewModel;

namespace Analysis7.ViewModel.ConcreteViewModel
{
    public class ProbabilityViewModel:BaseViewModel
    {
        private double _probability;

        public double Probability
        {
            get =>_probability;
            set
            {
                if (value > 1) _probability = 1;
                else if (value < 0) _probability = 0;
                else _probability = value;
                OnPropertyChanged(nameof(Probability));
            }
        }

        public ProbabilityViewModel(double value)
        {
            Probability = value;
        }
    }
}