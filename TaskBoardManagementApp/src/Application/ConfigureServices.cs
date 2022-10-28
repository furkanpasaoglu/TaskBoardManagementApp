using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TaskBoardManagementApp.Application.Comments.Rules;
using TaskBoardManagementApp.Application.Common.Behaviours;
using TaskBoardManagementApp.Application.IssueDetails.Rules;
using TaskBoardManagementApp.Application.Issues.Rules;

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
        
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));

        return services;
    }
}
