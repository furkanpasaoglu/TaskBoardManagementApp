namespace TaskBoardManagementApp.Domain.Entities;

/// <summary>
/// Task Entity.
/// </summary>
public class Issue : BaseAuditableEntity
{
    public Guid ProjectId { get; set; }
    public Guid AssigneeId { get; set; }
    public Guid ReporterId { get; set; }
    public int Number { get; set; }
    public string Name { get; set; }
    public IssueType Types { get; set; }
    public IssueStatus Status { get; set; }
    public DateTime DueDate { get; set; }
}
