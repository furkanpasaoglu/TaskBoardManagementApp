using AutoMapper;
using TaskBoardManagementApp.Application.Features.Comments.Commands.UpdateComment;
using TaskBoardManagementApp.Application.Features.Comments.Dtos;
using TaskBoardManagementApp.Domain.Entities;

namespace TaskBoardManagementApp.Application.Features.Comments.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreatedCommentDto, Comment>().ReverseMap();
        CreateMap<UpdateCommentDto, Comment>().ReverseMap();
        CreateMap<UpdateCommentCommand, Comment>().ReverseMap();
        CreateMap<CommentGetByIdDto, Comment>().ReverseMap();
        CreateMap<CommentListDto, Comment>().ReverseMap();
    }
}
