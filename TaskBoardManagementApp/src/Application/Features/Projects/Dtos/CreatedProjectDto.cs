using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoardManagementApp.Application.Features.Projects.Dtos;
public record CreatedProjectDto
{
    public Guid Id { get; set; }
    public string ProjectName { get; set; }
}
