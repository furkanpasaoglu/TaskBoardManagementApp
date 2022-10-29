using MediatR;
using TaskBoardManagementApp.Application.Common.Interfaces;
using TaskBoardManagementApp.Application.Features.IssueDetails.Dtos;
using TaskBoardManagementApp.Application.Features.IssueDetails.Rules;

namespace TaskBoardManagementApp.Application.Features.IssueDetails.Commands.DeleteIssueDetail;

public record DeleteIssueDetailCommand : IRequest<DeletedIssueDetailDto>
{
    public Guid Id { get; init; }
}

public class DeleteIssueDetailCommandHandler: IRequestHandler<DeleteIssueDetailCommand, DeletedIssueDetailDto>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IssueDetailBusinessRules _businessRules;

    public DeleteIssueDetailCommandHandler(IApplicationDbContext dbContext, IssueDetailBusinessRules businessRules)
    {
        _dbContext = dbContext;
        _businessRules = businessRules;
    }

    public async Task<DeletedIssueDetailDto> Handle(DeleteIssueDetailCommand request, CancellationToken cancellationToken)
    {
        await _businessRules.IssueDetailShouldBeExist(request.Id);
        
        var issueDetail = await _dbContext.IssueDetails
            .FindAsync(new object[] { request.Id }, cancellationToken);
        var deletedIssueDetail = _dbContext.IssueDetails.Remove(issueDetail);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return new DeletedIssueDetailDto { Id = deletedIssueDetail.Entity.Id };
    }
}