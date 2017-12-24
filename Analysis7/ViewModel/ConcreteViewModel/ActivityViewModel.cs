using Analysis7.Model.Entities;
using Analysis7.ViewModel.AbstractViewModel;

namespace Analysis7.ViewModel.ConcreteViewModel
{
    public class ActivityViewModel:BaseViewModel
    {
        private string _description;
        private string _reducing;
        private string _accepting;
        private string _avoiding;
        private string _transferring;
        private readonly Activity _modelActivity;

        public string Description
        {
            get=> _description;
            set {
                _description = value;
                _modelActivity.Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public string Reducing
        {
            get => _reducing;
            set
            {
                _reducing = value;
                _modelActivity.Reducing = value;
                OnPropertyChanged(nameof(Reducing));
            }
        }

        public string Accepting
        {
            get => _accepting;
            set
            {
                _accepting = value;
                _modelActivity.Accepting = value;
                OnPropertyChanged(nameof(Accepting));
            }
        }

        public string Avoiding
        {
            get => _avoiding;
            set
            {
                _avoiding = value;
                _modelActivity.Avoiding = value;
                OnPropertyChanged(nameof(Avoiding));
            }
        }

        public string Transferring
        {
            get => _transferring;
            set
            {
                _transferring = value;
                _modelActivity.Transferring = value;
                OnPropertyChanged(nameof(Transferring));

            }
        }

        public ActivityViewModel(Activity modelActivity)
        {
            _modelActivity = modelActivity;
            Description = _modelActivity.Description;
            Avoiding = _modelActivity.Avoiding;
            Accepting = _modelActivity.Accepting;
            Transferring = _modelActivity.Transferring;
            Reducing = _modelActivity.Reducing;
        }
    }
}