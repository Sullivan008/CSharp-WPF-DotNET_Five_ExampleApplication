using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.BusinessLogicLayer.MediatR.Abstractions;
using Application.BusinessLogicLayer.Modules.Parking.RequestModels;
using Application.BusinessLogicLayer.Modules.Parking.ResponseModels;
using Application.DataAccessLayer.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.BusinessLogicLayer.Modules.Parking.Queries
{
    public class GetParkingListByLicensePlateNumberQuery : IRequest<ParkingListResponseModel>
    {
        public string LicensePlateNumber { get; }

        public GetParkingListByLicensePlateNumberQuery(GetParkingListByLicensePlateNumberRequestModel model)
        {
            LicensePlateNumber = !string.IsNullOrWhiteSpace(model.LicensePlateNumber)
                ? model.LicensePlateNumber.Trim()
                : throw new ArgumentNullException(nameof(model.LicensePlateNumber), @"The value cannot be null!");
        }
    }

    public class GetParkingListByLicensePlateNumberQueryHandler : QueryBase<GetParkingListByLicensePlateNumberQuery, ParkingListResponseModel>
    {
        public GetParkingListByLicensePlateNumberQueryHandler(ParkingAppReadonlyDbContext context) : base(context)
        { }

        public override async Task<ParkingListResponseModel> Handle(GetParkingListByLicensePlateNumberQuery request, CancellationToken cancellationToken)
        {
            ParkingListResponseModel result = new()
            {
                ParkingList = await Context.Cars.Include(x => x.LoggedParkingPeriods)
                                                .Where(x => x.Card == null)
                                                .Where(x => x.LicensePlateNumber.ToLower() == request.LicensePlateNumber.ToLower())
                                                .SelectMany(x => x.LoggedParkingPeriods.Select(y => new ParkingListItemResponseModel
                                                {
                                                    LicensePlateNumber = x.LicensePlateNumber,
                                                    StartDate = y.StartDate,
                                                    EndDate = y.EndDate
                                                }))
                                                .ToListAsync(cancellationToken)
            };

            return result;
        }
    }
}
