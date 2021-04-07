using System.Collections.Generic;

namespace Application.Core.Services.Export.Models
{
    public class ExportDataModel<TDataSetType>
    {
        public string FileName { get; init; }

        public IReadOnlyCollection<TDataSetType> DataSet { get; init; }
    }
}
