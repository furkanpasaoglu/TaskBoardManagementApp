using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskBoardManagementApp.Application.Common.Behaviours.Caching;
using TaskBoardManagementApp.Application.Common.Interfaces;
using TaskBoardManagementApp.Application.Features.IssueDetails.Dtos;
using TaskBoardManagementApp.Application.Features.IssueDetails.Rules;

namespace TaskBoardManagementApp.Application.Features.IssueDetails.Queries.GetByIdIssueDetail;

public record GetByIdIssueDetailQuery : IRequest<IssueDetailGetByIdDto>, ICachableRequest
{
    public Guid Id { get; init; }

    public bool BypassCache => false;

    public string CacheKey => "GetByIdIssueDetailKey";

    public TimeSpan? SlidingExpiration => TimeSpan.FromMinutes(2);
}

public class GetByIdIssueDetailQueryHandler : IRequestHandler<GetByIdIssueDetailQuery, IssueDetailGetByIdDto>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IssueDetailBusinessRules _businessRules;

    public GetByIdIssueDetailQueryHandler(IApplicationDbContext dbContext, IMapper mapper,
        IssueDetailBusinessRules businessRules)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<IssueDetailGetByIdDto> Handle(GetByIdIssueDetailQuery request,
        CancellationToken cancellationToken)
    {
        await _businessRules.IssueDetailShouldBeExist(request.Id);

        var result =
            await _dbContext.IssueDetails.FirstOrDefaultAsync(x => x.Id == request.Id,
                cancellationToken: cancellationToken);
        return _mapper.Map<IssueDetailGetByIdDto>(result);
    }
}