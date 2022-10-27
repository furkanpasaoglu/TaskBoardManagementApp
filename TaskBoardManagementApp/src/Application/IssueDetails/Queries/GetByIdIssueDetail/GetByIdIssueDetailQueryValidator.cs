using FluentValidation;
using TaskBoardManagementApp.Application.IssueDetails.Constants;

namespace TaskBoardManagementApp.Application.IssueDetails.Queries.GetByIdIssueDetail;

public class GetByIdIssueDetailQueryValidator  : AbstractValidator<GetByIdIssueDetailQuery>
{
    public GetByIdIssueDetailQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithMessage(IssueDetailMessages.IdCannotBeEmpty);
    }
}