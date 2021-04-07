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
        private ICommand _filterByLicensePlateNumberCommand;
        public ICommand FilterByLicensePlateNumberCommand =>
            _filterByLicensePlateNumberCommand ??= new RelayCommandAsync(ExecuteFilterByLicensePlateNumberCommand, _ => CanExecuteFilterByLicensePlateNumberCommand(_licensePlateNumber));

        private static bool CanExecuteFilterByLicensePlateNumberCommand(string licensePlateNumber)
        {
            return !string.IsNullOrWhiteSpace(licensePlateNumber);
        }

        private async Task ExecuteFilterByLicensePlateNumberCommand()
        {
            GetParkingListByLicensePlateNumberRequestModel requestModel = new() { LicensePlateNumber = _licensePlateNumber };

            ParkingListResponseModel response = await _mediator.Send(new GetParkingListByLicensePlateNumberQuery(requestModel));

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
