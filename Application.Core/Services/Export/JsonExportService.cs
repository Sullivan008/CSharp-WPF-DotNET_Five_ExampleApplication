using System;
using System.IO;
using System.Threading.Tasks;
using Application.Core.Services.Export.Abstractions;
using Application.Core.Services.Export.Interfaces;
using Application.Core.Services.Export.Models;
using Newtonsoft.Json;

namespace Application.Core.Services.Export
{
    public class JsonExportService : BaseExport, IJsonExportService
    {
        public override Task ExportData<TDataSetType>(ExportDataModel<TDataSetType> model)
        {
            if (!IsExistExportsFolder())
            {
                CreateExportsFolder();
            }

            using (StreamWriter streamWriter = File.CreateText($@"{ExportsDirectory}\{model.FileName}_{DateTime.Now:yyyy-MM-dd_hh-mm-ss}.json"))
            {
                JsonSerializer serializer = new();

                serializer.Serialize(streamWriter, model.DataSet);
            }

            return Task.CompletedTask;
        }
    }
}
