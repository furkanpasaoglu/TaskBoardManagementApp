using Microsoft.EntityFrameworkCore;
using TaskBoardManagementApp.Application.Common.Exceptions;
using TaskBoardManagementApp.Application.Common.Interfaces;
using TaskBoardManagementApp.Application.Features.Issues.Constants;

namespace TaskBoardManagementApp.Application.Features.Issues.Rules;

public class IssueBusinessRules
{
    private readonly IApplicationDbContext _dbContext;

    public IssueBusinessRules(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task IssueNumberCannotBeDuplicated(int number)
    {
        var result = await _dbContext.Issues.FirstOrDefaultAsync(x => x.Number == number);
        if (result is not null)
            throw new BusinessException(IssueMessages.IssueNumberCannotBeDuplicated);
    }

    public async Task IssueTitleAlreadyUpdated(Guid id, string title)
    {
        var result = await _dbContext.Issues.FirstAsync(x => x.Id == id);

        if (result.Title == title)
            throw new BusinessException(IssueMessages.IssueTitleAlreadyUpdated);
    }

    public async Task IssueShouldBeExist(Guid id)
    {
        var result = await _dbContext.Issues.FirstOrDefaultAsync(x => x.Id == id);

        if (result is null)
            throw new BusinessException(IssueMessages.IssueIsNotFound);
    }
}
