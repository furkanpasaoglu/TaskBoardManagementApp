namespace TaskBoardManagementApp.Application.Features.IssueDetails.Dtos;

public record IssueDetailGetByIdDto
{
    public Guid Id { get; set; }
    public Guid IssueId { get;  set; }
    public string Description { get;  set; }
}