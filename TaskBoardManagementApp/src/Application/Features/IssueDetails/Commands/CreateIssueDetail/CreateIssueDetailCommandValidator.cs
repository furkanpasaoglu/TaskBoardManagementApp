using FluentValidation;
using TaskBoardManagementApp.Application.Features.IssueDetails.Constants;

namespace TaskBoardManagementApp.Application.Features.IssueDetails.Commands.CreateIssueDetail;

public class CreateIssueDetailCommandValidator : AbstractValidator<CreateIssueDetailCommand>
{
    public CreateIssueDetailCommandValidator()
    {
        RuleFor(x => x.IssueId)
            .NotEmpty()
            .NotNull()
            .WithMessage($"{IssueDetailMessages.IssueIdCannotBeEmpty}");
    }
}