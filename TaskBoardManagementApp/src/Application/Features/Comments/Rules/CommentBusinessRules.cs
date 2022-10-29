using Microsoft.EntityFrameworkCore;
using TaskBoardManagementApp.Application.Common.Exceptions;
using TaskBoardManagementApp.Application.Common.Interfaces;
using TaskBoardManagementApp.Application.Features.Comments.Constants;

namespace TaskBoardManagementApp.Application.Features.Comments.Rules;
public class CommentBusinessRules
{
    private readonly IApplicationDbContext _dbContext;

    public CommentBusinessRules(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task IssueIdShouldBeExist(Guid id)
    {
        var result = await _dbContext.Issues.FirstOrDefaultAsync(x => x.Id == id);

        if (result is null)
            throw new BusinessException(CommentMessages.IssueIdNotFound);
    }
    public async Task CommentIdShouldBeExist(Guid id)
    {
        var result = await _dbContext.Comments.FirstOrDefaultAsync(x => x.Id == id);

        if (result is null)
            throw new BusinessException(CommentMessages.CommentIdNotFound);
    }


    // TODO: Business rules will be create for ProjectId and UserId
}
