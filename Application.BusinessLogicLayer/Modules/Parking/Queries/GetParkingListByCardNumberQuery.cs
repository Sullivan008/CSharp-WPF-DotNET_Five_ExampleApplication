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
    public class GetParkingListByCardNumberQuery : IRequest<ParkingListResponseModel>
    {
        public string CardNumber { get; }

        public GetParkingListByCardNumberQuery(GetParkingListByCardNumberRequestModel model)
        {
            CardNumber = !string.IsNullOrWhiteSpace(model.CardNumber)
                ? model.CardNumber.Trim()
                : throw new ArgumentNullException(nameof(model.CardNumber), @"The value cannot be null!");
        }
    }

    public class GetParkingListByCardNumberQueryHandler : QueryBase<GetParkingListByCardNumberQuery, ParkingListResponseModel>
    {
        public GetParkingListByCardNumberQueryHandler(ParkingAppReadonlyDbContext context) : base(context)
        { }

        public override async Task<ParkingListResponseModel> Handle(GetParkingListByCardNumberQuery request, CancellationToken cancellationToken)
        {
            ParkingListResponseModel result = new()
            {
                ParkingList = await Context.Cars.Include(x => x.Card)
                                                .Include(x => x.LoggedParkingPeriods)
                                                .Where(x => x.Card != null)
                                                .Where(x => x.Card.Number.ToLower() == request.CardNumber.ToLower())
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
