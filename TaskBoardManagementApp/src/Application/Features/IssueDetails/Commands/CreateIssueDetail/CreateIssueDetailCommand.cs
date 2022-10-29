using AutoMapper;
using MediatR;
using TaskBoardManagementApp.Application.Common.Interfaces;
using TaskBoardManagementApp.Application.Features.IssueDetails.Dtos;
using TaskBoardManagementApp.Application.Features.IssueDetails.Rules;
using TaskBoardManagementApp.Domain.Entities;

namespace TaskBoardManagementApp.Application.Features.IssueDetails.Commands.CreateIssueDetail;

public record CreateIssueDetailCommand : IRequest<CreatedIssueDetailDto>
{
    public Guid IssueId { get; init; }
    public string Description { get; init; }
}

public class CreateIssueDetailCommandHandler : IRequestHandler<CreateIssueDetailCommand, CreatedIssueDetailDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IssueDetailBusinessRules _businessRules;

    public CreateIssueDetailCommandHandler(IApplicationDbContext context, IMapper mapper,
        IssueDetailBusinessRules businessRules)
    {
        _context = context;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<CreatedIssueDetailDto> Handle(CreateIssueDetailCommand request,
        CancellationToken cancellationToken)
    {
        await _businessRules.IssueShouldBeExist(request.IssueId);

        var issueDetail = new IssueDetail(request.IssueId, request.Description);
        var createdIssueDetail = await _context.IssueDetails.AddAsync(issueDetail, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return _mapper.Map<CreatedIssueDetailDto>(createdIssueDetail.Entity);
    }
}