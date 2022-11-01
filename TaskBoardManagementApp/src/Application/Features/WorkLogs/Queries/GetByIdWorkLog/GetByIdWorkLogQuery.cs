using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskBoardManagementApp.Application.Common.Behaviours.Caching;
using TaskBoardManagementApp.Application.Common.Interfaces;
using TaskBoardManagementApp.Application.Features.WorkLogs.Dtos;
using TaskBoardManagementApp.Application.Features.WorkLogs.Rules;

namespace TaskBoardManagementApp.Application.Features.WorkLogs.Queries.GetByIdWorkLog;

public record GetByIdWorkLogQuery : IRequest<WorkLogGetByIdDto>, ICachableRequest
{
    public Guid Id { get; init; }

    public bool BypassCache => false;

    public string CacheKey => "GetByIdWorkLogKey";

    public TimeSpan? SlidingExpiration => TimeSpan.FromMinutes(2);
}

public class GetByIdWorkLogQueryHandler : IRequestHandler<GetByIdWorkLogQuery, WorkLogGetByIdDto>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly WorkLogBusinessRules _businessRules;

    public GetByIdWorkLogQueryHandler(IApplicationDbContext dbContext, IMapper mapper, WorkLogBusinessRules businessRules)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<WorkLogGetByIdDto> Handle(GetByIdWorkLogQuery request, CancellationToken cancellationToken)
    {
        await _businessRules.WorkLogIdShouldBeExist(request.Id);
        
        var result = await _dbContext.WorkLogs.FirstOrDefaultAsync(x=>x.Id == request.Id, cancellationToken);
        return _mapper.Map<WorkLogGetByIdDto>(result);
    }
}