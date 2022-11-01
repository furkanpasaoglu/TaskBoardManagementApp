using AutoMapper;
using TaskBoardManagementApp.Application.Features.WorkLogs.Commands.UpdateWorkLog;
using TaskBoardManagementApp.Application.Features.WorkLogs.Dtos;
using TaskBoardManagementApp.Domain.Entities;

namespace TaskBoardManagementApp.Application.Features.WorkLogs.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreatedWorkLogDto, WorkLog>().ReverseMap();
        CreateMap<UpdatedWorkLogDto, WorkLog>().ReverseMap();
        CreateMap<UpdateWorkLogCommand, WorkLog>().ReverseMap();
        CreateMap<WorkLogGetByIdDto, WorkLog>().ReverseMap();
        CreateMap<WorkLogListDto, WorkLog>().ReverseMap();
    }
}