using MediatR;
using TaskBoardManagementApp.Application.Common.Interfaces;
using TaskBoardManagementApp.Application.Issues.Dtos;
using TaskBoardManagementApp.Application.Issues.Rules;
using TaskBoardManagementApp.Domain.Events.Issues;

namespace TaskBoardManagementApp.Application.Issues.Commands.DeleteIssue;

public record DeleteIssueCommand: IRequest<DeletedIssueDto>
{
    public Guid Id { get; init; }
}

public class DeleteIssueCommandHandler : IRequestHandler<DeleteIssueCommand, DeletedIssueDto>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IssueBusinessRules _businessRules;

    public DeleteIssueCommandHandler(IApplicationDbContext dbContext, IssueBusinessRules businessRules)
    {
        _dbContext = dbContext;
        _businessRules = businessRules;
    }

    public async Task<DeletedIssueDto> Handle(DeleteIssueCommand request, CancellationToken cancellationToken)
    {
        await _businessRules.IssueShouldBeExist(request.Id);

        var issue = await _dbContext.Issues
            .FindAsync(new object[] { request.Id }, cancellationToken);

        var deletedIssue = _dbContext.Issues.Remove(issue);

        issue.AddDomainEvent(new IssueDeletedEvent(issue));

        await _dbContext.SaveChangesAsync(cancellationToken);

        return new DeletedIssueDto { Id = deletedIssue.Entity.Id };
    }
}
