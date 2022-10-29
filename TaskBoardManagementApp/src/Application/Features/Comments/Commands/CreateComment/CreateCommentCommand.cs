using AutoMapper;
using MediatR;
using TaskBoardManagementApp.Application.Common.Interfaces;
using TaskBoardManagementApp.Application.Features.Comments.Dtos;
using TaskBoardManagementApp.Application.Features.Comments.Rules;
using TaskBoardManagementApp.Domain.Entities;

namespace TaskBoardManagementApp.Application.Features.Comments.Commands.CreateComment;
public record CreateCommentCommand : IRequest<CreatedCommentDto>
{
    public Guid ProjectId { get; init; }
    public Guid IssueId { get; init; }
    public Guid UserId { get; init; }
    public string Message { get; init; }
}

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, CreatedCommentDto>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly CommentBusinessRules _commentBusinessRules;

    public CreateCommentCommandHandler(IApplicationDbContext dbContext, IMapper mapper, CommentBusinessRules commentBusinessRules)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _commentBusinessRules = commentBusinessRules;
    }

    public async Task<CreatedCommentDto> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        await _commentBusinessRules.IssueIdShouldBeExist(request.IssueId);

        var comment = new Comment(request.ProjectId, request.IssueId, request.UserId, request.Message);

        var createdComment = await _dbContext.Comments.AddAsync(comment, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return _mapper.Map<CreatedCommentDto>(createdComment.Entity);
    }
}