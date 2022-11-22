using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskBoardManagementApp.Application.Common.Behaviours.Caching;
using TaskBoardManagementApp.Application.Common.Interfaces;
using TaskBoardManagementApp.Application.Features.Projects.Dtos;
using TaskBoardManagementApp.Application.Features.Projects.Rules;

namespace TaskBoardManagementApp.Application.Features.Projects.Queries.GetByIdProject;
public record GetByIdProjectQuery : IRequest<ProjectGetByIdDto>, ICachableRequest
{
    public Guid Id { get; init; }

    public bool BypassCache => false;

    public string CacheKey => "ProjectByIdKey";

    public TimeSpan? SlidingExpiration => TimeSpan.FromMinutes(2);
}

public class GetByIdProjectQueryHandler : IRequestHandler<GetByIdProjectQuery, ProjectGetByIdDto>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ProjectBusinessRules _businessRules;

    public GetByIdProjectQueryHandler(IApplicationDbContext dbContext, IMapper mapper, ProjectBusinessRules businessRules)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<ProjectGetByIdDto> Handle(GetByIdProjectQuery request, CancellationToken cancellationToken)
    {
        await _businessRules.ProjectShouldBeExist(request.Id);

        var result = await _dbContext.Projects.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        return _mapper.Map<ProjectGetByIdDto>(result);
    }
}