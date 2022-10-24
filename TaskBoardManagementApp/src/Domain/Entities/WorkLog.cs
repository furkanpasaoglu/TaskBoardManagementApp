using TaskBoardManagementApp.Domain.Validators;

namespace TaskBoardManagementApp.Domain.Entities;

/// <summary>
/// Work Log Entity.
/// </summary>
public class WorkLog : BaseAuditableEntity
{
    public Guid IssueId { get; private set; }
    public string Log { get; private set; }

    public WorkLog(Guid issueId, string log)
    {
        IssueId = DomainValidator.CheckNotNull(issueId);
        Log = DomainValidator.CheckNotNullOrWhiteSpace(log);
    }
}
