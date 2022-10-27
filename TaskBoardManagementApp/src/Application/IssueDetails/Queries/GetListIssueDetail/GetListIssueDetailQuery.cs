using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskBoardManagementApp.Application.Common.Interfaces;
using TaskBoardManagementApp.Application.IssueDetails.Dtos;

namespace TaskBoardManagementApp.Application.IssueDetails.Queries.GetListIssueDetail;

public record GetListIssueDetailQuery : IRequest<List<IssueDetailListDto>>
{
}

public class GetListIssueDetailQueryHandler : IRequestHandler<GetListIssueDetailQuery, List<IssueDetailListDto>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetListIssueDetailQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<IssueDetailListDto>> Handle(GetListIssueDetailQuery request, CancellationToken cancellationToken)
    {
        var result = await _dbContext.IssueDetails.ToListAsync(cancellationToken: cancellationToken);
        return _mapper.Map<List<IssueDetailListDto>>(result);
    }
}