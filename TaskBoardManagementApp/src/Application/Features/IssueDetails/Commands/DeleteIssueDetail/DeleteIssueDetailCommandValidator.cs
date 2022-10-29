using FluentValidation;
using TaskBoardManagementApp.Application.Features.IssueDetails.Constants;

namespace TaskBoardManagementApp.Application.Features.IssueDetails.Commands.DeleteIssueDetail;

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