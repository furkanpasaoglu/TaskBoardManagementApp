using System.Globalization;
using CsvHelper;
using TaskBoardManagementApp.Application.Common.Interfaces;
using TaskBoardManagementApp.Application.TodoLists.Queries.ExportTodos;
using TaskBoardManagementApp.Infrastructure.Files.Maps;

namespace TaskBoardManagementApp.Infrastructure.Files;
public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Configuration.RegisterClassMap<TodoItemRecordMap>();
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }
}
