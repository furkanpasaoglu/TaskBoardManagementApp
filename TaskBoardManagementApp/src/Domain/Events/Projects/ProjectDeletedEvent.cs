namespace TaskBoardManagementApp.Domain.Events.Projects;

public class ProjectDeletedEvent : BaseEvent
{
    public ProjectDeletedEvent(Project project)
    {
        Project = project;
    }
    public Project Project { get; set; }
}