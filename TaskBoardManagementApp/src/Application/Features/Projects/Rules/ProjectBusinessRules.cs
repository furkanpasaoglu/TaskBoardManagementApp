using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskBoardManagementApp.Application.Common.Exceptions;
using TaskBoardManagementApp.Application.Common.Interfaces;
using TaskBoardManagementApp.Application.Features.Projects.Constants;

namespace TaskBoardManagementApp.Application.Features.Projects.Rules;
public class ProjectBusinessRules
{
    private readonly IApplicationDbContext _dbContext;

    public ProjectBusinessRules(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task ProjectNameAlreadyUpdated(Guid id, string projectName)
    {
        var result = await _dbContext.Projects.FirstAsync(x => x.Id == id);

        if (result.ProjectName == projectName)
            throw new BusinessException(ProjectMessages.ProjectNameAlreadyUpdated);
    }

    public async Task ProjectShouldBeExist(Guid id)
    {
        var result = await _dbContext.Projects.FirstOrDefaultAsync(x => x.Id == id);

        if (result is null)
            throw new BusinessException(ProjectMessages.ProjectIsNotFound);
    }
}
