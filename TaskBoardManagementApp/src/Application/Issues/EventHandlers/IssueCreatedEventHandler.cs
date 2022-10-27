using MediatR;
using Microsoft.Extensions.Logging;
using TaskBoardManagementApp.Domain.Events.Issues;

namespace TaskBoardManagementApp.Application.Issues.EventHandlers;

public class IssueCreatedEventHandler : INotificationHandler<IssueCreatedEvent>
{
    private readonly ILogger<IssueCreatedEventHandler> _logger;

    public IssueCreatedEventHandler(ILogger<IssueCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(IssueCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("TaskBoardManagementApp Domain Event: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}
