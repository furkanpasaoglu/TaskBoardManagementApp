using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskBoardManagementApp.Application.Common.Interfaces;
using TaskBoardManagementApp.Application.Features.Issues.Dtos;

namespace TaskBoardManagementApp.Application.Features.Issues.Queries.GetListIssue;
public record GetListIssueQuery : IRequest<List<IssueListDto>>
{
}

public class GetListIssueQueryHandler : IRequestHandler<GetListIssueQuery, List<IssueListDto>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetListIssueQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<IssueListDto>> Handle(GetListIssueQuery request, CancellationToken cancellationToken)
    {
        var result = await _dbContext.Issues.ToListAsync(cancellationToken: cancellationToken);
        return _mapper.Map<List<IssueListDto>>(result);
    }
}
