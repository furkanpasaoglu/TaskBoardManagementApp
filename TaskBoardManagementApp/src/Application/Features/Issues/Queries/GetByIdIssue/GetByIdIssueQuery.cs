using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskBoardManagementApp.Application.Common.Behaviours.Caching;
using TaskBoardManagementApp.Application.Common.Interfaces;
using TaskBoardManagementApp.Application.Features.Issues.Dtos;
using TaskBoardManagementApp.Application.Features.Issues.Rules;

namespace TaskBoardManagementApp.Application.Features.Issues.Queries.GetByIdIssue;
public record GetByIdIssueQuery : IRequest<IssueGetByIdDto>, ICachableRequest
{
    public Guid Id { get; init; }

    public bool BypassCache => false;

    public string CacheKey => "IssueByIdKey";

    public TimeSpan? SlidingExpiration => TimeSpan.FromMinutes(2);
}

public class GetByIdIssueQueryHandler : IRequestHandler<GetByIdIssueQuery, IssueGetByIdDto>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IssueBusinessRules _businessRules;

    public GetByIdIssueQueryHandler(IApplicationDbContext dbContext, IMapper mapper, IssueBusinessRules businessRules)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<IssueGetByIdDto> Handle(GetByIdIssueQuery request, CancellationToken cancellationToken)
    {
        await _businessRules.IssueShouldBeExist(request.Id);

        var result = await _dbContext.Issues.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        return _mapper.Map<IssueGetByIdDto>(result);
    }
}
