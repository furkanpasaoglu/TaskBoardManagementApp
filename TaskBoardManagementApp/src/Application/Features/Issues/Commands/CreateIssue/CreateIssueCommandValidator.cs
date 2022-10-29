using FluentValidation;
using TaskBoardManagementApp.Application.Features.Issues.Constants;

namespace TaskBoardManagementApp.Application.Features.Issues.Commands.CreateIssue;

public class CreateIssueCommandValidator : AbstractValidator<CreateIssueCommand>
{
    public CreateIssueCommandValidator()
    {
        RuleFor(x => x.Title)
            .MinimumLength(12)
            .NotEmpty()
            .WithMessage($"{IssueMessages.MinTitleLengthMessage} or {IssueMessages.TitleCannotBeEmpty}");
    }
}
