using System;

namespace Application.BusinessLogicLayer.Modules.Parking.ResponseModels
{
    public class ParkingListItemResponseModel
    {
        public string LicensePlateNumber { get; init; }

        public DateTime StartDate { get; init; }

        public DateTime? EndDate { get; init; }
    }
}
