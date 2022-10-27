using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskBoardManagementApp.Application.Common.Interfaces;
using TaskBoardManagementApp.Application.IssueDetails.Dtos;
using TaskBoardManagementApp.Application.IssueDetails.Rules;

namespace TaskBoardManagementApp.Application.IssueDetails.Queries.GetByIdIssueDetail;

public record GetByIdIssueDetailQuery : IRequest<IssueDetailGetByIdDto>
{
    public Guid Id { get; init; }
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