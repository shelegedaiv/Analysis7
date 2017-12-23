﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analysis7.Model.Observer;
using Analysis7.ViewModel.AbstractViewModel;
using System.Collections.ObjectModel;
using System.Windows.Media;
using Analysis7.Model.Entities;

namespace Analysis7.ViewModel.ConcreteViewModel
{
    public class PriceEntityViewModel: RiskEntityViewModel, IListener

    {

        private int _price;
        public int Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
         
        private ObservableCollection<double> _expertProbabilities;
        public ObservableCollection<double> ExpertProbabilities
        {
            get => _expertProbabilities;
            set
            {
                _expertProbabilities = value;
                _expertProbabilities.CollectionChanged += (source, e) =>
                {
                    _modelEvent.Price.ExpertProbabilities[e.NewStartingIndex].Value = ExpertProbabilities[e.NewStartingIndex];
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
                    _modelEvent.Price.CoefExpertProbabilities[e.NewStartingIndex] = CoefExpertProbabilities[e.NewStartingIndex];
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

        public PriceEntityViewModel(Event modelEvent, Color color) : base(modelEvent.Name, modelEvent.Description, modelEvent.Probability.AverageProbability.Value)
        {
            _modelEvent = modelEvent;
            GroupColor = color;
            _modelEvent.Price.AttachListener(this);
            Update();
        }

        public void Update()
        {
            ExpertProbabilities = new ObservableCollection<double>(_modelEvent.Price.ExpertProbabilities.Select(ev => ev.Value).ToList());
            CoefExpertProbabilities = new ObservableCollection<double>(_modelEvent.Price.CoefExpertProbabilities.Select(ev => ev).ToList());
            AverageProbability = _modelEvent.Price.AverageProbability.Value;
            CoefAverageProbability = _modelEvent.Price.CoefAverageProbability;
        }
    }
}
