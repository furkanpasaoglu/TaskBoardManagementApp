using FluentValidation;
using TaskBoardManagementApp.Application.Features.Issues.Constants;

namespace TaskBoardManagementApp.Application.Features.Issues.Commands.DeleteIssue;

public class DeleteIssueCommandValidator : AbstractValidator<DeleteIssueCommand>
{
    public DeleteIssueCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithMessage($"{IssueMessages.IdCannotBeEmpty}");
    }
}