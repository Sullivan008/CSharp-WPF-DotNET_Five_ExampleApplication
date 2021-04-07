using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Application.BusinessLogicLayer.Modules.Parking.Queries;
using Application.BusinessLogicLayer.Modules.Parking.RequestModels;
using Application.BusinessLogicLayer.Modules.Parking.ResponseModels;
using Application.Client.Core.Commands;

namespace Application.Client.Windows.Main.ViewModels
{
    public partial class MainWindowViewModel
    {
        private ICommand _filterByCardNumberCommand;
        public ICommand FilterByCardNumberCommand =>
            _filterByCardNumberCommand ??= new RelayCommandAsync(ExecuteFilterByCardNumberCommand, _ => CanExecuteFilterByCardNumberCommand(_cardNumber));

        private static bool CanExecuteFilterByCardNumberCommand(string cardNumber)
        {
            return !string.IsNullOrWhiteSpace(cardNumber);
        }

        private async Task ExecuteFilterByCardNumberCommand()
        {
            GetParkingListByCardNumberRequestModel requestModel = new() { CardNumber = _cardNumber };

            ParkingListResponseModel response = await _mediator.Send(new GetParkingListByCardNumberQuery(requestModel));

            ParkingList = new ObservableCollection<ParkingListItemViewModel>(response.ParkingList.Select(x =>
                new ParkingListItemViewModel
                {
                    LicensePlateNumber = x.LicensePlateNumber,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate
                }));
        }
    }
}
