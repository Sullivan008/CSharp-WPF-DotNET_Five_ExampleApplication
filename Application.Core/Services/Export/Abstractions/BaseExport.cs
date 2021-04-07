using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Application.Core.Services.Export.Models;

namespace Application.Core.Services.Export.Abstractions
{
    public abstract class BaseExport
    {
        protected readonly string ExportsDirectory;

        protected BaseExport()
        {
            ExportsDirectory = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\exports";
        }

        protected bool IsExistExportsFolder()
        {
            return Directory.Exists(ExportsDirectory);
        }

        protected void CreateExportsFolder()
        {
            Directory.CreateDirectory(ExportsDirectory);
        }

        public abstract Task ExportData<TDataSetType>(ExportDataModel<TDataSetType> model);
    }
}
