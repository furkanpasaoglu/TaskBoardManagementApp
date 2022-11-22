namespace TaskBoardManagementApp.Application.Features.Projects.Dtos;

public record ProjectListDto
{
    public Guid Id { get; set; }
    public string ProjectName { get; set; }
}
