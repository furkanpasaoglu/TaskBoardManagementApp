using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardManagementApp.Application.Common.Interfaces;

namespace TaskBoardManagementApp.Application.Issues.Rules;

public class IssueBusinessRules
{
    private readonly IApplicationDbContext _dbContext;

    public IssueBusinessRules(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // TODO: Business rules will be created..
}
