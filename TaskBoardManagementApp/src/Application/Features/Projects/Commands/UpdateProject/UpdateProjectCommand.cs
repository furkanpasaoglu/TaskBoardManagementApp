using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TaskBoardManagementApp.Application.Common.Interfaces;
using TaskBoardManagementApp.Application.Features.Projects.Dtos;
using TaskBoardManagementApp.Application.Features.Projects.Rules;

namespace TaskBoardManagementApp.Application.Features.Projects.Commands.UpdateProject;
public record UpdateProjectCommand : IRequest<UpdatedProjectDto>
{
    public Guid Id { get; init; }
    public string ProjectName { get; init; }
}

public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, UpdatedProjectDto>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ProjectBusinessRules _businessRules;

    public UpdateProjectCommandHandler(IApplicationDbContext dbContext, IMapper mapper, ProjectBusinessRules businessRules)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<UpdatedProjectDto> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        await _businessRules.ProjectShouldBeExist(request.Id);
        await _businessRules.ProjectNameAlreadyUpdated(request.Id, request.ProjectName);

        var Project = await _dbContext.Projects
            .FindAsync(new object[] { request.Id }, cancellationToken);

        var mapped = _mapper.Map(request, Project);

        var updatedProject = _dbContext.Projects.Update(mapped);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<UpdatedProjectDto>(updatedProject.Entity);
    }
}