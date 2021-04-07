using System.Collections.Generic;

namespace Application.BusinessLogicLayer.Modules.Parking.ResponseModels
{
    public class ParkingListResponseModel
    {
        public IEnumerable<ParkingListItemResponseModel> ParkingList { get; init; }
    }
}
