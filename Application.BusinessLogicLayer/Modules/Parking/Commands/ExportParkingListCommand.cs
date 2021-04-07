using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.BusinessLogicLayer.MediatR.Abstractions;
using Application.BusinessLogicLayer.Modules.Parking.Dtos;
using Application.BusinessLogicLayer.Modules.Parking.RequestModels;
using Application.Core.MediatR.Structs;
using Application.Core.Services.Export.Interfaces;
using Application.Core.Services.Export.Models;
using Application.DataAccessLayer.Context;
using MediatR;

namespace Application.BusinessLogicLayer.Modules.Parking.Commands
{
    public class ExportParkingListCommand : IRequest<Result>
    {
        public IReadOnlyCollection<ExportParkingListItemDto> ExportList { get; }

        public ExportParkingListCommand(ExportParkingListRequestModel model)
        {
            ExportList = model.ExportList.Select(x => new ExportParkingListItemDto
            {
                LicensePlateNumber = x.LicensePlateNumber,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                IntervalInMinutes = x.IntervalInMinutes
            }).ToList();
        }
    }

    public class ExportParkingListCommandHandler : CommandBase<ExportParkingListCommand, Result>
    {
        private readonly IJsonExportService _jsonExportService;

        public ExportParkingListCommandHandler(ParkingAppDbContext context, IJsonExportService jsonExportService) : base(context)
        {
            _jsonExportService = jsonExportService;
        }

        public override async Task<Result> Handle(ExportParkingListCommand request, CancellationToken cancellationToken)
        {
            ExportDataModel<ExportParkingListItemDto> exportDataModel = new()
            {
                DataSet = request.ExportList,
                FileName = "export-result"
            };

            await _jsonExportService.ExportData(exportDataModel);

            return Result.Success();
        }
    }
}
