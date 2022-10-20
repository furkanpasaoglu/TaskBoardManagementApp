using Microsoft.EntityFrameworkCore;
using TaskBoardManagementApp.Domain.Entities;

namespace TaskBoardManagementApp.Application.Common.Interfaces;
public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
