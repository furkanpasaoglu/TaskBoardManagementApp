using FluentValidation;
using TaskBoardManagementApp.Application.Features.Comments.Constants;

namespace TaskBoardManagementApp.Application.Features.Comments.Commands.DeleteComment;
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
