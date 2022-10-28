using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TaskBoardManagementApp.Application.Comments.Constants;

namespace TaskBoardManagementApp.Application.Comments.Queries.GetByIdComment;
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
