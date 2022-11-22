using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoardManagementApp.Domain.Events.Projects;
public class ProjectCreatedEvent : BaseEvent
{
    public ProjectCreatedEvent(Project project)
    {
        Project = project;
    }
    public Project Project { get; set; }
}
