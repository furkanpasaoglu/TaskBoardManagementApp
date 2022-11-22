using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardManagementApp.Domain.Validators;

namespace TaskBoardManagementApp.Domain.Entities;

/// <summary>
/// Project Entity.
/// </summary>
public class Project : BaseFullAuditableEntity
{

    public string ProjectName { get; set; }

    public Project(string projectName)
    {
        ProjectName = DomainValidator.CheckNotNullOrWhiteSpace(projectName);
    }
}
