using TaskBoardManagementApp.Application.Common.Mappings;
using TaskBoardManagementApp.Domain.Entities;

namespace TaskBoardManagementApp.Application.TodoLists.Queries.ExportTodos;
public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
