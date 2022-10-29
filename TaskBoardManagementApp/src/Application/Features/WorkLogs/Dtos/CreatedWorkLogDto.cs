namespace TaskBoardManagementApp.Application.Features.WorkLogs.Dtos;

public record CreatedWorkLogDto
{
    public Guid Id { get; set; }
    public Guid IssueId { get;  set; }
    public string Log { get; set; }
}