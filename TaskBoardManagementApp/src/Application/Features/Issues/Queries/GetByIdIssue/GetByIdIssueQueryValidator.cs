using FluentValidation;
using TaskBoardManagementApp.Application.Features.Issues.Constants;

namespace TaskBoardManagementApp.Application.Features.Issues.Queries.GetByIdIssue;
public class GetByIdIssueQueryValidator : AbstractValidator<GetByIdIssueQuery>
{
    public GetByIdIssueQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithMessage(IssueMessages.IdCannotBeEmpty);
    }
}
