using FluentValidation;
using TaskBoardManagementApp.Application.IssueDetails.Constants;

namespace TaskBoardManagementApp.Application.IssueDetails.Commands.UpdateIssueDetail;

public class UpdateIssueDetailCommandValidator : AbstractValidator<UpdateIssueDetailCommand>
{
    public UpdateIssueDetailCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage($"{IssueDetailMessages.IssueDetailIdCannotBeEmpty}");
        
        RuleFor(x => x.IssueId)
            .NotEmpty()
            .NotNull()
            .WithMessage($"{IssueDetailMessages.IssueIdCannotBeEmpty}");
    }
}