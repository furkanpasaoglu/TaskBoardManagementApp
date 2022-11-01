using AutoMapper;
using MediatR;
using TaskBoardManagementApp.Application.Common.Interfaces;
using TaskBoardManagementApp.Application.Features.Issues.Dtos;
using TaskBoardManagementApp.Application.Features.Issues.Rules;
using TaskBoardManagementApp.Domain.Entities;
using TaskBoardManagementApp.Domain.Enums;
using TaskBoardManagementApp.Domain.Events.Issues;

namespace TaskBoardManagementApp.Application.Features.Issues.Commands.CreateIssue;

public record CreateIssueCommand : IRequest<CreatedIssueDto>
{
    public Guid ProjectId { get; init; }
    public Guid AssigneeId { get; init; }
    public Guid ReporterId { get; init; }
    public int Number { get; init; }
    public string Title { get; init; }
    public IssueType Types { get; init; }
    public IssueStatus Status { get; init; }
    public DateTime DueDate { get; init; }
}

public class CreateIssueCommandHandler : IRequestHandler<CreateIssueCommand, CreatedIssueDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IssueBusinessRules _issueBusinessRules;

    public CreateIssueCommandHandler(IApplicationDbContext context, IMapper mapper, IssueBusinessRules issueBusinessRules)
    {
        _context = context;
        _mapper = mapper;
        _issueBusinessRules = issueBusinessRules;
    }

    public async Task<CreatedIssueDto> Handle(CreateIssueCommand request, CancellationToken cancellationToken)
    {
        await _issueBusinessRules.IssueNumberCannotBeDuplicated(request.Number);

        var issue = new Issue(request.ProjectId, request.AssigneeId, request.ReporterId, request.Number, request.Title, request.Types, request.Status, request.DueDate);

        issue.AddDomainEvent(new IssueCreatedEvent(issue));

        var createdIssue = await _context.Issues.AddAsync(issue, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CreatedIssueDto>(createdIssue.Entity);
    }
}