using TaskBoardManagementApp.Application.TodoLists.Queries.ExportTodos;

namespace TaskBoardManagementApp.Application.Common.Interfaces;
public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
