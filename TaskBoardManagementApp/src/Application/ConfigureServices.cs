using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TaskBoardManagementApp.Application.Common.Behaviours;
using TaskBoardManagementApp.Application.Common.Behaviours.Caching;
using TaskBoardManagementApp.Application.Features.Comments.Rules;
using TaskBoardManagementApp.Application.Features.IssueDetails.Rules;
using TaskBoardManagementApp.Application.Features.Issues.Rules;
using TaskBoardManagementApp.Application.Features.Projects.Rules;
using TaskBoardManagementApp.Application.Features.WorkLogs.Rules;

namespace TaskBoardManagementApp.Application;
public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        
        services.AddScoped<IssueBusinessRules>();
        services.AddScoped<IssueDetailBusinessRules>();
        services.AddScoped<CommentBusinessRules>();
        services.AddScoped<WorkLogBusinessRules>();
        services.AddScoped<ProjectBusinessRules>();

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheRemovingBehavior<,>));

        return services;
    }
}
