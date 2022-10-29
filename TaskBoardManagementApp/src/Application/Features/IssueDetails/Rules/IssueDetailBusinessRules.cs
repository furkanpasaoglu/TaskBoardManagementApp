using Microsoft.EntityFrameworkCore;
using TaskBoardManagementApp.Application.Common.Exceptions;
using TaskBoardManagementApp.Application.Common.Interfaces;
using TaskBoardManagementApp.Application.Features.IssueDetails.Constants;

namespace TaskBoardManagementApp.Application.Features.IssueDetails.Rules;

public class IssueDetailBusinessRules
{
    private readonly IApplicationDbContext _dbContext;

    public IssueDetailBusinessRules(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task IssueDetailShouldBeExist(Guid id)
    {
        var result = await _dbContext.IssueDetails.FirstOrDefaultAsync(x => x.Id == id);

        if (result is null)
            throw new BusinessException(IssueDetailMessages.IssueDetailIsNotFound);
    }
    
    public async Task IssueShouldBeExist(Guid id)
    {
        var result = await _dbContext.Issues.FirstOrDefaultAsync(x => x.Id == id);

        if (result is null)
            throw new BusinessException(IssueDetailMessages.IssueIsNotFound);
    }
    
}