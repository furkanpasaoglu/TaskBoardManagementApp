namespace TaskBoardManagementApp.Application.Features.WorkLogs.Dtos;

public record WorkLogGetByIdDto
{
    public Guid Id { get; set; }
    public Guid IssueId { get;  set; }
    public string Log { get; set; }
}