using FluentValidation;
using TaskBoardManagementApp.Application.Comments.Constants;

namespace TaskBoardManagementApp.Application.Comments.Commands.UpdateComment;
public class UpdateCommentCommandValidator : AbstractValidator<UpdateCommentCommand>
{
    public UpdateCommentCommandValidator()
    {
        RuleFor(x => x.Message)
            .MinimumLength(12)
            .NotEmpty()
            .WithMessage($"{CommentMessages.MinCommentLengthMessage} or {CommentMessages.CommentCannotBeEmpty}");
    }
}
