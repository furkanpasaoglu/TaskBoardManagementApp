using MediatR;
using TaskBoardManagementApp.Application.Common.Interfaces;
using TaskBoardManagementApp.Application.Features.Comments.Dtos;
using TaskBoardManagementApp.Application.Features.Comments.Rules;

namespace TaskBoardManagementApp.Application.Features.Comments.Commands.DeleteComment;
public record DeleteCommentCommand : IRequest<DeletedCommentDto>
{
    public Guid Id { get; init; }
}

public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, DeletedCommentDto>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly CommentBusinessRules _businessRules;

    public DeleteCommentCommandHandler(IApplicationDbContext dbContext, CommentBusinessRules businessRules)
    {
        _dbContext = dbContext;
        _businessRules = businessRules;
    }

    public async Task<DeletedCommentDto> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        await _businessRules.CommentIdShouldBeExist(request.Id);

        var comment = await _dbContext.Comments
            .FindAsync(new object[] { request.Id }, cancellationToken);

        var deletedComment = _dbContext.Comments.Remove(comment);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return new DeletedCommentDto { Id = deletedComment.Entity.Id };
    }
}