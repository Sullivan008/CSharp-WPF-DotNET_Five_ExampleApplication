using System.Collections.ObjectModel;
using Application.Client.Core.SystemNotification.Services.Interfaces;
using Application.Client.Core.ViewModels;
using Application.Client.Windows.Main.ViewModels.Interfaces;
using MediatR;

namespace Application.Client.Windows.Main.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        private readonly IMediator _mediator;

        private readonly ISystemNotificationService _systemNotificationService;

        public MainWindowViewModel(IMediator mediator, ISystemNotificationService systemNotificationService)
        {
            _mediator = mediator;
            _systemNotificationService = systemNotificationService;
        }

        #region PROPERTIES Getters/ Setters

        private string _licensePlateNumber;
        public string LicensePlateNumber
        {
            get => _licensePlateNumber;
            set
            {
                _licensePlateNumber = value;

                OnPropertyChanged();
            }
        }

        private string _cardNumber;
        public string CardNumber
        {
            get => _cardNumber;
            set
            {
                _cardNumber = value;

                OnPropertyChanged();
            }
        }

        private ObservableCollection<ParkingListItemViewModel> _parkingList = new();
        public ObservableCollection<ParkingListItemViewModel> ParkingList
        {
            get => _parkingList;
            set
            {
                _parkingList = value;

                OnPropertyChanged();
            }
        }

        #endregion
    }
}
