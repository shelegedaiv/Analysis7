﻿using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Media;
using Analysis7.Model.Entities;
using Analysis7.Model.Observer;
using Analysis7.ViewModel.AbstractViewModel;

namespace Analysis7.ViewModel.ConcreteViewModel
{
    public class EventViewModel : RiskEntityViewModel, IListener
    {
        private ObservableCollection<double> _expertProbabilities;
        public ObservableCollection<double> ExpertProbabilities
        {
            get => _expertProbabilities;
            set
            {
                _expertProbabilities = value;
                _expertProbabilities.CollectionChanged += (source, e) =>
                {
                    _modelEvent.Probability.ExpertProbabilities[e.NewStartingIndex].Value = ExpertProbabilities[e.NewStartingIndex];
                };
                OnPropertyChanged(nameof(ExpertProbabilities));
            }
        }

        private ObservableCollection<double> _coefExpertProbabilities;
        public ObservableCollection<double> CoefExpertProbabilities
        {
            get => _coefExpertProbabilities;
            set
            {
                _coefExpertProbabilities = value;
                _coefExpertProbabilities.CollectionChanged += (source, e) =>
                {
                    _modelEvent.Probability.CoefExpertProbabilities[e.NewStartingIndex] = CoefExpertProbabilities[e.NewStartingIndex];
                };
                OnPropertyChanged(nameof(CoefExpertProbabilities));
            }
        }

        private double _coefAverageProbability;

        public double CoefAverageProbability
        {
            get => _coefAverageProbability;
            set
            {
                _coefAverageProbability = value;
                OnPropertyChanged(nameof(CoefAverageProbability));
            }
        }
        public Color GroupColor { get; set; }
        private readonly Event _modelEvent;

        public EventViewModel(Event modelEvent, Color color) : base(modelEvent.Name, modelEvent.Description, modelEvent.Probability.AverageProbability.Value)
        {
            _modelEvent = modelEvent;
            GroupColor = color;
            _modelEvent.Probability.AttachListener(this);
            Update();
        }

        public void Update()
        {
            ExpertProbabilities = new ObservableCollection<double>(_modelEvent.Probability.ExpertProbabilities.Select(ev => ev.Value).ToList());
            CoefExpertProbabilities = new ObservableCollection<double>(_modelEvent.Probability.CoefExpertProbabilities.Select(ev => ev).ToList());
            AverageProbability = _modelEvent.Probability.AverageProbability.Value;
            CoefAverageProbability = _modelEvent.Probability.CoefAverageProbability;
        }
    }
}