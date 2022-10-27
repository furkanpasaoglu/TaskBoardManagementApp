using FluentValidation;
using TaskBoardManagementApp.Application.Issues.Constants;

namespace TaskBoardManagementApp.Application.Issues.Commands.DeleteIssue;

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