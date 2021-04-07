using System;
using Application.Client.Core.ViewModels;

namespace Application.Client.Windows.Main.ViewModels
{
    public class ParkingListItemViewModel : ViewModelBase
    {
        public string LicensePlateNumber { get; init; }

        public DateTime StartDate { get; init; }

        public DateTime? EndDate { get; init; }

        public double? IntervalInMinutes
        {
            get
            {
                if (EndDate.HasValue)
                {
                    return (EndDate.Value - StartDate).TotalMinutes;
                }

                return null;
            }
        }
    }
}
