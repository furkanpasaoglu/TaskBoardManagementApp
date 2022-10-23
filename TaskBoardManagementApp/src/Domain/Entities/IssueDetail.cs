using TaskBoardManagementApp.Domain.Validators;

namespace TaskBoardManagementApp.Domain.Entities;

/// <summary>
/// Task Detail Entity
/// </summary>
public class IssueDetail : BaseAuditableEntity
{
    public Guid IssueId { get; private set; }
    public string Description { get; private set; }
    public string Comments { get; private set; }

    public IssueDetail(Guid issueId, string description, string comments)
    {
        IssueId = DomainValidator.CheckNotNull(issueId);
        Description = DomainValidator.CheckNotNullOrWhiteSpace(description);
        Comments = DomainValidator.CheckNotNullOrWhiteSpace(comments);
    }
}
