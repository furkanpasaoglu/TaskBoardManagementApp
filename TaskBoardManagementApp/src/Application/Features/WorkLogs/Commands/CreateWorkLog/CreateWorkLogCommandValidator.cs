using FluentValidation;
using TaskBoardManagementApp.Application.Features.WorkLogs.Constants;

namespace TaskBoardManagementApp.Application.Features.WorkLogs.Commands.CreateWorkLog;

public class CreateWorkLogCommandValidator : AbstractValidator<CreateWorkLogCommand>
{
    public CreateWorkLogCommandValidator()
    {
        RuleFor(x => x.IssueId)
            .NotNull()
            .NotEmpty()
            .WithMessage(WorkLogMessages.IssueIdCannotBeEmpty);
    }
}