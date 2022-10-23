using Microsoft.EntityFrameworkCore;
using TaskBoardManagementApp.Domain.Entities;

namespace TaskBoardManagementApp.Application.Common.Interfaces;
public interface IApplicationDbContext
{
    DbSet<Issue> Issues{ get; }
    DbSet<IssueDetail> IssueDetails { get; }
    DbSet<WorkLog> WorkLogs { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
