using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskBoardManagementApp.Application.Common.Interfaces;
using TaskBoardManagementApp.Application.Issues.Dtos;
using TaskBoardManagementApp.Domain.Enums;

namespace TaskBoardManagementApp.Application.Issues.Queries.GetListIssues;
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
        var result = await _dbContext.Issues.ToListAsync();
        return _mapper.Map<List<IssueListDto>>(result);
    }
}
