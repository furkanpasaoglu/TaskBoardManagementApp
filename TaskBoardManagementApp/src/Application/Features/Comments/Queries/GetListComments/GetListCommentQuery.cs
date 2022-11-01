using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskBoardManagementApp.Application.Common.Interfaces;
using TaskBoardManagementApp.Application.Features.Comments.Dtos;

namespace TaskBoardManagementApp.Application.Features.Comments.Queries.GetListComments;
public record GetListCommentQuery : IRequest<List<CommentListDto>>
{

}

public class GetListCommentQueryHandler : IRequestHandler<GetListCommentQuery, List<CommentListDto>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetListCommentQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<CommentListDto>> Handle(GetListCommentQuery request, CancellationToken cancellationToken)
    {
        var result = await _dbContext.Comments.ToListAsync(cancellationToken: cancellationToken);
        return _mapper.Map<List<CommentListDto>>(result);
    }
}