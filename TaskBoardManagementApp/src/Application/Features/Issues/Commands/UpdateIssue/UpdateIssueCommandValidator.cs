using FluentValidation;
using TaskBoardManagementApp.Application.Features.Issues.Constants;

namespace TaskBoardManagementApp.Application.Features.Issues.Commands.UpdateIssue;

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
