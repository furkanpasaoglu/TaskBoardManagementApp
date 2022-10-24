using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoardManagementApp.Domain.Events.Issues;

public class IssueCreatedEvent : BaseEvent
{
    public IssueCreatedEvent(Issue issue)
    {
        Issue = issue;
    }

    public Issue Issue { get; set; }
}
