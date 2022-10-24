using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoardManagementApp.Domain.Events.Issues;

public class IssueDeletedEvent : BaseEvent
{
    public IssueDeletedEvent(Issue issue)
    {
        Issue = issue;
    }

    public Issue Issue { get; set; }
}
