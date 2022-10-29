using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskBoardManagementApp.Application.Common.Interfaces;
using TaskBoardManagementApp.Application.Features.WorkLogs.Dtos;

namespace TaskBoardManagementApp.Application.Features.WorkLogs.Queries.GetListWorkLog;

public record GetListWorkLogQuery : IRequest<List<WorkLogListDto>>
{
    
}

public class GetListWorkLogQueryHandler : IRequestHandler<GetListWorkLogQuery, List<WorkLogListDto>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetListWorkLogQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<WorkLogListDto>> Handle(GetListWorkLogQuery request, CancellationToken cancellationToken)
    {
        var result = await _dbContext.WorkLogs.ToListAsync(cancellationToken: cancellationToken);
        return _mapper.Map<List<WorkLogListDto>>(result);
    }
}