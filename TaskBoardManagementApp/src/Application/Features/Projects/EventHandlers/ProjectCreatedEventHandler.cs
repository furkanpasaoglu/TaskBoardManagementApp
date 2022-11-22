using MediatR;
using Microsoft.Extensions.Logging;
using TaskBoardManagementApp.Domain.Events.Projects;

namespace TaskBoardManagementApp.Application.Features.Issues.EventHandlers;

public class ProjectCreatedEventHandler : INotificationHandler<ProjectCreatedEvent>
{
    private readonly ILogger<ProjectCreatedEventHandler> _logger;

    public ProjectCreatedEventHandler(ILogger<ProjectCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(ProjectCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("TaskBoardManagementApp Domain Event: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}