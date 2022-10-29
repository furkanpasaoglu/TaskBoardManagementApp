namespace TaskBoardManagementApp.Application.Features.Comments.Dtos;
public record CommentGetByIdDto
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public Guid IssueId { get; set; }
    public Guid UserId { get; set; }
    public string Message { get; set; }
}
