using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TaskBoardManagementApp.Application.Common.Interfaces;
using TaskBoardManagementApp.Application.Features.Projects.Dtos;
using TaskBoardManagementApp.Application.Features.Projects.Rules;
using TaskBoardManagementApp.Domain.Events.Projects;

namespace TaskBoardManagementApp.Application.Features.Projects.Commands.DeleteProject;
public record DeleteProjectCommand : IRequest<DeletedProjectDto>
{
    public Guid Id { get; init; }
}

public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, DeletedProjectDto>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly ProjectBusinessRules _businessRules;

    public DeleteProjectCommandHandler(IApplicationDbContext dbContext, ProjectBusinessRules businessRules)
    {
        _dbContext = dbContext;
        _businessRules = businessRules;
    }

    public async Task<DeletedProjectDto> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        await _businessRules.ProjectShouldBeExist(request.Id);

        var Project = await _dbContext.Projects
            .FindAsync(new object[] { request.Id }, cancellationToken);

        var deletedProject = _dbContext.Projects.Remove(Project);

        Project.AddDomainEvent(new ProjectDeletedEvent(Project));

        await _dbContext.SaveChangesAsync(cancellationToken);

        return new DeletedProjectDto { Id = deletedProject.Entity.Id };
    }
}