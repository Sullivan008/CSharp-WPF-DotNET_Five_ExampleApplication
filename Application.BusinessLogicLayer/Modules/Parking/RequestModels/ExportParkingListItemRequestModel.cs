using System;

namespace Application.BusinessLogicLayer.Modules.Parking.RequestModels
{
    public class ExportParkingListItemRequestModel
    {
        public string LicensePlateNumber { get; init; }

        public DateTime StartDate { get; init; }

        public DateTime? EndDate { get; init; }

        public double? IntervalInMinutes { get; init; }
    }
}
