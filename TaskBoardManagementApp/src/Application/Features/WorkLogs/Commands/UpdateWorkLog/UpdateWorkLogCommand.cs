using AutoMapper;
using MediatR;
using TaskBoardManagementApp.Application.Common.Interfaces;
using TaskBoardManagementApp.Application.Features.WorkLogs.Dtos;
using TaskBoardManagementApp.Application.Features.WorkLogs.Rules;

namespace TaskBoardManagementApp.Application.Features.WorkLogs.Commands.UpdateWorkLog;

public record UpdateWorkLogCommand : IRequest<UpdatedWorkLogDto>
{
    public Guid Id { get; init; }
    public Guid IssueId { get;  init; }
    public string Log { get;  init; }
}

public class UpdateWorkLogCommandHandler : IRequestHandler<UpdateWorkLogCommand, UpdatedWorkLogDto>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly WorkLogBusinessRules _businessRules;

    public UpdateWorkLogCommandHandler(IApplicationDbContext dbContext, IMapper mapper, WorkLogBusinessRules businessRules)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<UpdatedWorkLogDto> Handle(UpdateWorkLogCommand request, CancellationToken cancellationToken)
    {
        await _businessRules.WorkLogIdShouldBeExist(request.Id);
        await _businessRules.IssueShouldBeExist(request.IssueId);
        
        var workLog = await _dbContext.WorkLogs.FindAsync(new object[]{request.Id}, cancellationToken);
        var mapped = _mapper.Map(request, workLog);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return _mapper.Map<UpdatedWorkLogDto>(mapped);
    }
}