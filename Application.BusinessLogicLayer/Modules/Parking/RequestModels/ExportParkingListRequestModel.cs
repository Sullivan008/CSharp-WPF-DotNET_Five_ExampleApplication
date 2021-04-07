using System.Collections.Generic;

namespace Application.BusinessLogicLayer.Modules.Parking.RequestModels
{
    public class ExportParkingListRequestModel
    {
        public IReadOnlyCollection<ExportParkingListItemRequestModel> ExportList { get; init; }
    }
}
