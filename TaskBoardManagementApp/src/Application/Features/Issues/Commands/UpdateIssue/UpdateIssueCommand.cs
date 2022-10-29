using AutoMapper;
using MediatR;
using TaskBoardManagementApp.Application.Common.Interfaces;
using TaskBoardManagementApp.Application.Features.Issues.Dtos;
using TaskBoardManagementApp.Application.Features.Issues.Rules;
using TaskBoardManagementApp.Domain.Enums;

namespace TaskBoardManagementApp.Application.Features.Issues.Commands.UpdateIssue;

public record class UpdateIssueCommand : IRequest<UpdatedIssueDto>
{
    public Guid Id { get; init; }
    public Guid ProjectId { get; init; }
    public Guid AssigneeId { get; init; }
    public Guid ReporterId { get; init; }
    public int Number { get; init; }
    public string Title { get; init; }
    public IssueType Types { get; init; }
    public IssueStatus Status { get; init; }
    public DateTime DueDate { get; init; }
}

public class UpdateIssueCommandHandler : IRequestHandler<UpdateIssueCommand, UpdatedIssueDto>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IssueBusinessRules _businessRules;

    public UpdateIssueCommandHandler(IApplicationDbContext dbContext, IMapper mapper, IssueBusinessRules businessRules)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<UpdatedIssueDto> Handle(UpdateIssueCommand request, CancellationToken cancellationToken)
    {
        await _businessRules.IssueShouldBeExist(request.Id);
        await _businessRules.IssueNumberCannotBeDuplicated(request.Number);
        await _businessRules.IssueTitleAlreadyUpdated(request.Id, request.Title);

        var issue = await _dbContext.Issues
            .FindAsync(new object[] { request.Id }, cancellationToken);

        var mapped = _mapper.Map(request, issue);

        var updatedIssue = _dbContext.Issues.Update(mapped);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<UpdatedIssueDto>(updatedIssue.Entity);
    }
}
