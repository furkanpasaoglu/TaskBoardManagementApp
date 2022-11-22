using FluentValidation;
using TaskBoardManagementApp.Application.Features.Issues.Constants;
using TaskBoardManagementApp.Application.Features.Projects.Constants;

namespace TaskBoardManagementApp.Application.Features.Projects.Commands.CreateProject;

public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator()
    {
        RuleFor(x => x.ProjectName)
            .MinimumLength(2)
            .NotEmpty()
            .WithMessage($"{ProjectMessages.MinProjectLengthMessage} or {ProjectMessages.ProjectCannotBeEmpty}");
    }
}
