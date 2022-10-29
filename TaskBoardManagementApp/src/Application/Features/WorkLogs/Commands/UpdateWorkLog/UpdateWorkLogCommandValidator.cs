using FluentValidation;
using TaskBoardManagementApp.Application.Features.WorkLogs.Constants;

namespace TaskBoardManagementApp.Application.Features.WorkLogs.Commands.UpdateWorkLog;

public class UpdateWorkLogCommandValidator : AbstractValidator<UpdateWorkLogCommand>
{
    public UpdateWorkLogCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage(WorkLogMessages.IdCannotBeEmpty);
        
        RuleFor(x => x.IssueId)
            .NotEmpty()
            .NotNull()
            .WithMessage(WorkLogMessages.IssueIdCannotBeEmpty);
    }
}