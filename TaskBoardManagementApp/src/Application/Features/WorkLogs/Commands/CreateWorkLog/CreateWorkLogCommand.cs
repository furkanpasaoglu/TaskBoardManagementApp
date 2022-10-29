using AutoMapper;
using MediatR;
using TaskBoardManagementApp.Application.Common.Interfaces;
using TaskBoardManagementApp.Application.Features.WorkLogs.Dtos;
using TaskBoardManagementApp.Application.Features.WorkLogs.Rules;
using TaskBoardManagementApp.Domain.Entities;

namespace TaskBoardManagementApp.Application.Features.WorkLogs.Commands.CreateWorkLog;

public record CreateWorkLogCommand : IRequest<CreatedWorkLogDto>
{
    public Guid IssueId { get;  init; }
    public string Log { get;  init; }
}

public class CreateWorkLogCommandHandler : IRequestHandler<CreateWorkLogCommand, CreatedWorkLogDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly WorkLogBusinessRules _businessRules;

    public CreateWorkLogCommandHandler(IApplicationDbContext context, IMapper mapper, WorkLogBusinessRules businessRules)
    {
        _context = context;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<CreatedWorkLogDto> Handle(CreateWorkLogCommand request, CancellationToken cancellationToken)
    {
        await _businessRules.IssueShouldBeExist(request.IssueId);
        
        var workLog = new WorkLog(request.IssueId, request.Log);
        
        var createdWorkLog = await _context.WorkLogs.AddAsync(workLog, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CreatedWorkLogDto>(createdWorkLog.Entity);
    }
}


