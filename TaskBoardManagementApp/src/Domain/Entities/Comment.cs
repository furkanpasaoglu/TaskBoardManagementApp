using TaskBoardManagementApp.Domain.Validators;

namespace TaskBoardManagementApp.Domain.Entities;
public class Comment : BaseFullAuditableEntity
{
    public Guid ProjectId { get; set; }
    public Guid IssueId { get; set; }
    public Guid UserId { get; set; }
    public string Message { get; set; }

    public Comment(Guid projectId, Guid issueId, Guid userId, string message)
    {
        ProjectId = DomainValidator.CheckNotNull(projectId);
        IssueId = DomainValidator.CheckNotNull(issueId);
        UserId = DomainValidator.CheckNotNull(userId);
        Message = DomainValidator.CheckNotNullOrWhiteSpace(message);
    }
}
