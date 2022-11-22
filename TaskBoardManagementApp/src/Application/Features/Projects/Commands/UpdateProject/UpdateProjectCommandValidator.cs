using FluentValidation;
using TaskBoardManagementApp.Application.Features.Projects.Commands.UpdateProject;
using TaskBoardManagementApp.Application.Features.Projects.Constants;

namespace TaskBoardManagementApp.Application.Features.Projects.Commands.UpdateProject;

public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
{
    public UpdateProjectCommandValidator()
    {
        RuleFor(x => x.ProjectName)
            .MinimumLength(2)
            .NotEmpty()
            .WithMessage($"{ProjectMessages.MinProjectLengthMessage} or {ProjectMessages.ProjectCannotBeEmpty}");
    }
}