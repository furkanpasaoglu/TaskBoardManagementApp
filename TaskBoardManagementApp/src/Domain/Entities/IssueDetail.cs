namespace TaskBoardManagementApp.Domain.Entities;

/// <summary>
/// Task Detail Entity
/// </summary>
public class IssueDetail : BaseAuditableEntity
{
    public Guid IssueId { get; set; }
    public string Description { get; set; }
    public string Comments { get; set; }
}
