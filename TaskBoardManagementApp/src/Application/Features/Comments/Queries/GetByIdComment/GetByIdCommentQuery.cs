using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskBoardManagementApp.Application.Common.Behaviours.Caching;
using TaskBoardManagementApp.Application.Common.Interfaces;
using TaskBoardManagementApp.Application.Features.Comments.Dtos;
using TaskBoardManagementApp.Application.Features.Comments.Rules;

namespace TaskBoardManagementApp.Application.Features.Comments.Queries.GetByIdComment;
public record GetByIdCommentQuery : IRequest<CommentGetByIdDto>, ICachableRequest
{
    public Guid Id { get; init; }

    public bool BypassCache => false;

    public string CacheKey => "GetByIdCommentKey";

    public TimeSpan? SlidingExpiration => TimeSpan.FromMinutes(2);
}

public class GetByIdCommentQueryHandler : IRequestHandler<GetByIdCommentQuery, CommentGetByIdDto>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly CommentBusinessRules _businessRules;

    public GetByIdCommentQueryHandler(IApplicationDbContext dbContext, IMapper mapper, CommentBusinessRules businessRules)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<CommentGetByIdDto> Handle(GetByIdCommentQuery request, CancellationToken cancellationToken)
    {
        await _businessRules.CommentIdShouldBeExist(request.Id);

        var comment = await _dbContext.Comments.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        return _mapper.Map<CommentGetByIdDto>(comment);
    }
}
