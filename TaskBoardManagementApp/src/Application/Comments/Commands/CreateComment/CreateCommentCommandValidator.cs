using FluentValidation;
using TaskBoardManagementApp.Application.Comments.Constants;

namespace TaskBoardManagementApp.Application.Comments.Commands.CreateComment;
public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
{
    public CreateCommentCommandValidator()
    {
        RuleFor(x => x.Message)
            .MinimumLength(12)
            .NotEmpty()
            .WithMessage($"{CommentMessages.MinCommentLengthMessage} or {CommentMessages.CommentCannotBeEmpty}");
    }
}
