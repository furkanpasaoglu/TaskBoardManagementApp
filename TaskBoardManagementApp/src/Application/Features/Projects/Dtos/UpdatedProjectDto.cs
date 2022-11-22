namespace TaskBoardManagementApp.Application.Features.Projects.Dtos;

public record UpdatedProjectDto
{
    public Guid Id { get; set; }
    public string ProjectName { get; set; }
}
