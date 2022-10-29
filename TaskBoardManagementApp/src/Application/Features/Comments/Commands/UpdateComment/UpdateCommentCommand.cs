using AutoMapper;
using MediatR;
using TaskBoardManagementApp.Application.Common.Interfaces;
using TaskBoardManagementApp.Application.Features.Comments.Dtos;
using TaskBoardManagementApp.Application.Features.Comments.Rules;

namespace TaskBoardManagementApp.Application.Features.Comments.Commands.UpdateComment;
public record UpdateCommentCommand : IRequest<UpdateCommentDto>
{
    public Guid Id { get; init; }
    public Guid ProjectId { get; init; }
    public Guid IssueId { get; init; }
    public Guid UserId { get; init; }
    public string Message { get; init; }
}

public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, UpdateCommentDto>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly CommentBusinessRules _businessRules;

    public UpdateCommentCommandHandler(IApplicationDbContext dbContext, IMapper mapper, CommentBusinessRules businessRules)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<UpdateCommentDto> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        await _businessRules.CommentIdShouldBeExist(request.Id);
        await _businessRules.IssueIdShouldBeExist(request.IssueId);

        var comment = await _dbContext.Comments
            .FindAsync(new object[] { request.Id }, cancellationToken);

        var mapped = _mapper.Map(request, comment);

        var updatedComment = _dbContext.Comments.Update(mapped);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<UpdateCommentDto>(updatedComment.Entity);
    }
}