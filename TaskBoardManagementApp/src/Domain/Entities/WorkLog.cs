namespace TaskBoardManagementApp.Domain.Entities;

/// <summary>
/// Work Log Entity.
/// </summary>
public class WorkLog : BaseAuditableEntity
{
    public Guid IssueId { get; set; }
    public string Log { get; set; }
}
