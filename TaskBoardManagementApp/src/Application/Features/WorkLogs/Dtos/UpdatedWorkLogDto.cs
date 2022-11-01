namespace TaskBoardManagementApp.Application.Features.WorkLogs.Dtos;

public record UpdatedWorkLogDto
{
    public Guid Id { get; set; }
    public Guid IssueId { get;  set; }
    public string Log { get; set; }
}