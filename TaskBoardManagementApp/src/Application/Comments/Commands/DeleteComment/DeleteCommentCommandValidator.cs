using FluentValidation;
using TaskBoardManagementApp.Application.Comments.Constants;

namespace TaskBoardManagementApp.Application.Comments.Commands.DeleteComment;
public class DeleteCommentCommandValidator : AbstractValidator<DeleteCommentCommand>
{
    public DeleteCommentCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithMessage($"{CommentMessages.IdCannotBeEmpty}");
    }
}
