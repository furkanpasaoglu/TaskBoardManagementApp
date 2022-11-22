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
using TaskBoardManagementApp.Domain.Entities;
using TaskBoardManagementApp.Domain.Events.Projects;

namespace TaskBoardManagementApp.Application.Features.Projects.Commands.CreateProject;
public record CreateProjectCommand : IRequest<CreatedProjectDto>
{
    public string ProjectName { get; set; }
}

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, CreatedProjectDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ProjectBusinessRules _projectBusinessRules;

    public CreateProjectCommandHandler(IApplicationDbContext context, IMapper mapper, ProjectBusinessRules projectBusinessRules)
    {
        _context = context;
        _mapper = mapper;
        _projectBusinessRules = projectBusinessRules;
    }

    public async Task<CreatedProjectDto> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = new Project(request.ProjectName);

        project.AddDomainEvent(new ProjectCreatedEvent(project));

        var createdProject = await _context.Projects.AddAsync(project, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CreatedProjectDto>(createdProject.Entity);
    }
}