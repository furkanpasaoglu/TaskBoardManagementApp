using TaskBoardManagementApp.Domain.Validators;

namespace TaskBoardManagementApp.Domain.Entities;

/// <summary>
/// Task Entity.
/// </summary>
public class Issue : BaseAuditableEntity
{
    public Guid ProjectId { get; private set; }
    public Guid AssigneeId { get; private set; }
    public Guid ReporterId { get; private set; }
    public int Number { get; private set; }
    public string Title { get; private set; }
    public IssueType Types { get; private set; }
    public IssueStatus Status { get; private set; }
    public DateTime DueDate { get; private set; }

    public Issue(Guid projectId, Guid assigneeId, Guid reporterId, int number, string title, IssueType types, IssueStatus status, DateTime dueDate)
    {
        ProjectId = DomainValidator.CheckNotNull(projectId);
        AssigneeId = DomainValidator.CheckNotNull(assigneeId);
        ReporterId = DomainValidator.CheckNotNull(reporterId);
        Number = number;
        Title = DomainValidator.CheckNotNullOrWhiteSpace(title);
        Types = types;
        Status = status;
        DueDate = dueDate;
    }
}
