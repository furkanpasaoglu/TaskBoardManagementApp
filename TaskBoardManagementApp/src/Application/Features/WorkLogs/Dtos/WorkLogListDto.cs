namespace TaskBoardManagementApp.Application.Features.WorkLogs.Dtos;

public record WorkLogListDto
{
    public Guid Id { get; set; }
    public Guid IssueId { get;  set; }
    public string Log { get; set; }
}