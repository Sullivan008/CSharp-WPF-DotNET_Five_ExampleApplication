using System.Threading.Tasks;
using Application.Core.Services.Export.Models;

namespace Application.Core.Services.Export.Interfaces
{
    public interface IJsonExportService
    {
        public Task ExportData<TDataSetType>(ExportDataModel<TDataSetType> model);
    }
}
