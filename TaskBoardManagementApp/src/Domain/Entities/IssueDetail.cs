using TaskBoardManagementApp.Domain.Validators;

namespace TaskBoardManagementApp.Domain.Entities;

/// <summary>
/// Task Detail Entity
/// </summary>
public class IssueDetail : BaseFullAuditableEntity
{
    public Guid IssueId { get; private set; }
    public string Description { get; private set; }

    public IssueDetail(Guid issueId, string description)
    {
        IssueId = DomainValidator.CheckNotNull(issueId);
        Description = DomainValidator.CheckNotNullOrWhiteSpace(description);
    }
}
