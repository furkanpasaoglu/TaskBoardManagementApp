using AutoMapper;
using MediatR;
using TaskBoardManagementApp.Application.Common.Interfaces;
using TaskBoardManagementApp.Application.IssueDetails.Dtos;
using TaskBoardManagementApp.Application.IssueDetails.Rules;

namespace TaskBoardManagementApp.Application.IssueDetails.Commands.UpdateIssueDetail;

public record UpdateIssueDetailCommand : IRequest<UpdatedIssueDetailDto>
{
    public Guid Id { get; init; }
    public Guid IssueId { get;  init; }
    public string Description { get;  init; }
    public string Comments { get; init; }
}

public class UpdateIssueDetailCommandHandler : IRequestHandler<UpdateIssueDetailCommand, UpdatedIssueDetailDto>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IssueDetailBusinessRules _businessRules;

    public UpdateIssueDetailCommandHandler(IApplicationDbContext dbContext, IMapper mapper, IssueDetailBusinessRules businessRules)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<UpdatedIssueDetailDto> Handle(UpdateIssueDetailCommand request, CancellationToken cancellationToken)
    {
        await _businessRules.IssueDetailShouldBeExist(request.Id);
        await _businessRules.IssueShouldBeExist(request.IssueId);
        
        var issueDetail = await _dbContext.IssueDetails
            .FindAsync(new object[] { request.Id }, cancellationToken);
        
        var mapped = _mapper.Map(request, issueDetail);
        var updatedIssueDetail = _dbContext.IssueDetails.Update(mapped);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return _mapper.Map<UpdatedIssueDetailDto>(updatedIssueDetail.Entity);
    }
}