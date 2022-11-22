using FluentValidation;
using TaskBoardManagementApp.Application.Features.Projects.Constants;

namespace TaskBoardManagementApp.Application.Features.Projects.Queries.GetByIdProject;
public class GetByIdProjectQueryValidator : AbstractValidator<GetByIdProjectQuery>
{
    public GetByIdProjectQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithMessage(ProjectMessages.IdCannotBeEmpty);
    }
}
