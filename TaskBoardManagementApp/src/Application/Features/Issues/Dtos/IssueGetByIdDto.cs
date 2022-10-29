using TaskBoardManagementApp.Domain.Enums;

namespace TaskBoardManagementApp.Application.Features.Issues.Dtos;
public record IssueGetByIdDto
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
