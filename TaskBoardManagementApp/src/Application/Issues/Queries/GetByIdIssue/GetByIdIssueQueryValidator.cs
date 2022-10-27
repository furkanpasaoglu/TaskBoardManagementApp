using FluentValidation;
using TaskBoardManagementApp.Application.Issues.Constants;

namespace TaskBoardManagementApp.Application.Issues.Queries.GetByIdIssue;
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
