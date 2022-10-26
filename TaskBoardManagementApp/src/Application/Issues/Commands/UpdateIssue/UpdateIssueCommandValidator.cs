using FluentValidation;
using TaskBoardManagementApp.Application.Issues.Constants;

namespace TaskBoardManagementApp.Application.Issues.Commands.UpdateIssue;

public class UpdateIssueCommandValidator : AbstractValidator<UpdateIssueCommand>
{
    public UpdateIssueCommandValidator()
    {
        RuleFor(x => x.Title)
            .MinimumLength(12)
            .NotEmpty()
            .WithMessage($"{IssueMessages.MinTitleLengthMessage} or {IssueMessages.TitleCannotBeEmpty}");
    }
}
