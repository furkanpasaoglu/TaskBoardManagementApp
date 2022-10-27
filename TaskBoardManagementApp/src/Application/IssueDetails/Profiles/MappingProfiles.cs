using AutoMapper;
using TaskBoardManagementApp.Application.IssueDetails.Commands.UpdateIssueDetail;
using TaskBoardManagementApp.Application.IssueDetails.Dtos;
using TaskBoardManagementApp.Domain.Entities;

namespace TaskBoardManagementApp.Application.IssueDetails.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreatedIssueDetailDto, IssueDetail>().ReverseMap();
        CreateMap<UpdatedIssueDetailDto, IssueDetail>().ReverseMap();
        CreateMap<UpdateIssueDetailCommand, IssueDetail>().ReverseMap();
        CreateMap<IssueDetailGetByIdDto, IssueDetail>().ReverseMap();
        CreateMap<IssueDetailListDto, IssueDetail>().ReverseMap();
    }
}