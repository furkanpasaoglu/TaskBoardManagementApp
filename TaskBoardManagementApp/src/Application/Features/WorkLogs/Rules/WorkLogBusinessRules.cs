using Microsoft.EntityFrameworkCore;
using TaskBoardManagementApp.Application.Common.Exceptions;
using TaskBoardManagementApp.Application.Common.Interfaces;
using TaskBoardManagementApp.Application.Features.WorkLogs.Constants;

namespace TaskBoardManagementApp.Application.Features.WorkLogs.Rules;

public class WorkLogBusinessRules
{
    private readonly IApplicationDbContext _dbContext;

    public WorkLogBusinessRules(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task IssueShouldBeExist(Guid requestIssueId)
    {
        var result =  await _dbContext.Issues.FirstOrDefaultAsync(x=>x.Id == requestIssueId);
        if (result is null)
            throw new BusinessException(WorkLogMessages.IssueIsNotFound);
    }

    public async Task WorkLogIdShouldBeExist(Guid requestId)
    {
        var result = await _dbContext.WorkLogs.FirstOrDefaultAsync(x => x.Id == requestId);
        if (result is null)
            throw new BusinessException(WorkLogMessages.WorkLogIsNotFound);
    }
}