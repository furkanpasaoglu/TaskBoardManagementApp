using TaskBoardManagementApp.Domain.Enums;

namespace TaskBoardManagementApp.Application.Issues.Dtos;

public record CreatedIssueDto
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public Guid AssigneeId { get; set; }
    public Guid ReporterId { get; set; }
    public int Number { get; set; }
    public string Title { get; set; }
    public IssueType Types { get; set; }
    public IssueStatus Status { get; set; }
    public DateTime DueDate { get; set; }
}
