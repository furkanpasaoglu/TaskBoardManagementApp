using FluentValidation;
using TaskBoardManagementApp.Application.Features.IssueDetails.Constants;

namespace TaskBoardManagementApp.Application.Features.IssueDetails.Queries.GetByIdIssueDetail;

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