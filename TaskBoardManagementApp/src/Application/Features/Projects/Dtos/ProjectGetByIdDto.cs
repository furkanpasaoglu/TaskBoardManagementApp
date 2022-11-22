namespace TaskBoardManagementApp.Application.Features.Projects.Dtos;

public record ProjectGetByIdDto
{
    public Guid Id { get; set; }
    public string ProjectName { get; set; }
}
