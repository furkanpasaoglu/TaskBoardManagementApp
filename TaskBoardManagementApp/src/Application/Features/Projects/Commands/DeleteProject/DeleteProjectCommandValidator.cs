using FluentValidation;
using TaskBoardManagementApp.Application.Features.Projects.Constants;

namespace TaskBoardManagementApp.Application.Features.Projects.Commands.DeleteProject;

public class DeleteProjectCommandValidator : AbstractValidator<DeleteProjectCommand>
{
    public DeleteProjectCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithMessage($"{ProjectMessages.IdCannotBeEmpty}");
    }
}