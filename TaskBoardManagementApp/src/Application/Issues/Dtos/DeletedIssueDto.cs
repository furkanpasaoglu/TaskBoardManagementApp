using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoardManagementApp.Application.Issues.Dtos;
public record DeletedIssueDto
{
    public Guid Id { get; set; }
}
