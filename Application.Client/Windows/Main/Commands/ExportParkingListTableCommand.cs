using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Application.BusinessLogicLayer.Modules.Parking.Commands;
using Application.BusinessLogicLayer.Modules.Parking.RequestModels;
using Application.Client.Core.Commands;
using Application.Core.MediatR.Structs;

namespace Application.Client.Windows.Main.ViewModels
{
    public partial class MainWindowViewModel
    {
        private ICommand _exportParkingListTableCommand;
        public ICommand ExportParkingListTableCommand =>
            _exportParkingListTableCommand ??= new RelayCommandAsync(ExecuteExportParkingListTableCommand, _ => CanExecuteExportParkingListTableCommand(_parkingList));

        private static bool CanExecuteExportParkingListTableCommand(ObservableCollection<ParkingListItemViewModel> parkingList)
        {
            return parkingList.Any();
        }

        private async Task ExecuteExportParkingListTableCommand()
        {
            ExportParkingListRequestModel requestModel = new()
            {
                ExportList = _parkingList.Select(x => new ExportParkingListItemRequestModel
                {
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    LicensePlateNumber = x.LicensePlateNumber,
                    IntervalInMinutes = x.IntervalInMinutes
                }).ToList()
            };

            Result result = await _mediator.Send(new ExportParkingListCommand(requestModel));

            if (result.IsSuccessFul)
            {
                _systemNotificationService.ShowSuccess("Export was successful! You can find the export result in the root directory /exports folder of the application!");
            }
            else
            {
                _systemNotificationService.ShowError("Export was failed! Please contact IT Help Desk!");
            }
        }
    }
}
