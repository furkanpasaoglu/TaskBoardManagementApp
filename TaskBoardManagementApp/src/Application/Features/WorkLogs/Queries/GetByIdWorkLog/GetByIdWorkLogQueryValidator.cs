using FluentValidation;
using TaskBoardManagementApp.Application.Features.WorkLogs.Constants;

namespace TaskBoardManagementApp.Application.Features.WorkLogs.Queries.GetByIdWorkLog;

public class GetByIdWorkLogQueryValidator : AbstractValidator<GetByIdWorkLogQuery>
{
    public GetByIdWorkLogQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithMessage(WorkLogMessages.IdCannotBeEmpty);
    }
}