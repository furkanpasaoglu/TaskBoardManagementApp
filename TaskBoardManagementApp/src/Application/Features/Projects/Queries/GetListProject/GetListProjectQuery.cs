using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskBoardManagementApp.Application.Common.Behaviours.Caching;
using TaskBoardManagementApp.Application.Common.Interfaces;
using TaskBoardManagementApp.Application.Features.Projects.Dtos;

namespace TaskBoardManagementApp.Application.Features.Projects.Queries.GetListProject;
public record GetListProjectQuery : IRequest<List<ProjectListDto>>, ICachableRequest
{
    public bool BypassCache => false;
    public string CacheKey => "ProjectListKey";
    public TimeSpan? SlidingExpiration => TimeSpan.FromMinutes(2);
}

public class GetListProjectQueryHandler : IRequestHandler<GetListProjectQuery, List<ProjectListDto>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetListProjectQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<ProjectListDto>> Handle(GetListProjectQuery request, CancellationToken cancellationToken)
    {
        var result = await _dbContext.Projects.ToListAsync(cancellationToken: cancellationToken);
        return _mapper.Map<List<ProjectListDto>>(result);
    }
}
