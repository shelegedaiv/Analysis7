namespace Analysis7.ViewModel.AbstractViewModel
{
    public abstract class RiskEntityViewModel:BaseViewModel
    {
        public string Name { get; }
        public string Description { get; }
        private double _averageProbability;
        public double AverageProbability
        {
            get => _averageProbability;
            set
            {
                _averageProbability = value;
                OnPropertyChanged(nameof(AverageProbability));
            }
        }

        protected RiskEntityViewModel(string name, string description, double averageProbability)
        {
            Name = name;
            Description = description;
            AverageProbability = averageProbability;//could be removed
        }
    }
}