using FluentValidation;
using TaskBoardManagementApp.Application.Features.WorkLogs.Constants;

namespace TaskBoardManagementApp.Application.Features.WorkLogs.Commands.DeleteWorkLog;

public class DeleteWorkLogCommandValidator : AbstractValidator<DeleteWorkLogCommand>
{
    public DeleteWorkLogCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithMessage(WorkLogMessages.IdCannotBeEmpty);
    }
}