using AutoMapper;
using TaskBoardManagementApp.Application.Issues.Commands.UpdateIssue;
using TaskBoardManagementApp.Application.Issues.Dtos;
using TaskBoardManagementApp.Domain.Entities;

namespace TaskBoardManagementApp.Application.Issues.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreatedIssueDto, Issue>().ReverseMap();
        CreateMap<UpdatedIssueDto, Issue>().ReverseMap();
        CreateMap<UpdateIssueCommand, Issue>().ReverseMap();
        CreateMap<IssueGetByIdDto, Issue>().ReverseMap();
        CreateMap<IssueListDto, Issue>().ReverseMap();
    }
}
