using FluentValidation;
using TaskBoardManagementApp.Application.Features.Comments.Constants;

namespace TaskBoardManagementApp.Application.Features.Comments.Queries.GetByIdComment;
public class GetByIdCommentQueryValidator : AbstractValidator<GetByIdCommentQuery>
{
    public GetByIdCommentQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithMessage(CommentMessages.IdCannotBeEmpty);
    }
}
