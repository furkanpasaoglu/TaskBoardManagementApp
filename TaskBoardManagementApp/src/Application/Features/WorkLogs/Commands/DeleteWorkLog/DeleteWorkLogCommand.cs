using MediatR;
using TaskBoardManagementApp.Application.Common.Interfaces;
using TaskBoardManagementApp.Application.Features.WorkLogs.Dtos;
using TaskBoardManagementApp.Application.Features.WorkLogs.Rules;

namespace TaskBoardManagementApp.Application.Features.WorkLogs.Commands.DeleteWorkLog;

public record DeleteWorkLogCommand : IRequest<DeletedWorkLogDto>
{
    public Guid Id { get; init; }
}

public class DeleteWorkLogCommandHandler : IRequestHandler<DeleteWorkLogCommand, DeletedWorkLogDto>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly WorkLogBusinessRules _businessRules;

    public DeleteWorkLogCommandHandler(IApplicationDbContext dbContext, WorkLogBusinessRules businessRules)
    {
        _dbContext = dbContext;
        _businessRules = businessRules;
    }

    public async Task<DeletedWorkLogDto> Handle(DeleteWorkLogCommand request, CancellationToken cancellationToken)
    {
        await _businessRules.WorkLogIdShouldBeExist(request.Id);

        var workLog = await _dbContext.WorkLogs.FindAsync(new object[] { request.Id }, cancellationToken);
        var deletedWorkLog = _dbContext.WorkLogs.Remove(workLog);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return new DeletedWorkLogDto { Id = deletedWorkLog.Entity.Id };
    }
}