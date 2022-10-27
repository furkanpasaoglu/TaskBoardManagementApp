using FluentValidation;
using TaskBoardManagementApp.Application.IssueDetails.Constants;

namespace TaskBoardManagementApp.Application.IssueDetails.Commands.DeleteIssueDetail;

public class DeleteIssueDetailCommandValidator : AbstractValidator<DeleteIssueDetailCommand>
{
    public DeleteIssueDetailCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage($"{IssueDetailMessages.IssueDetailIdCannotBeEmpty}");
    }
}