using AutoMapper;
using TaskBoardManagementApp.Application.Comments.Commands.UpdateComment;
using TaskBoardManagementApp.Application.Comments.Dtos;
using TaskBoardManagementApp.Domain.Entities;

namespace TaskBoardManagementApp.Application.Comments.Profiles;
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
