using AutoMapper;
using TaskBoardManagementApp.Application.Features.Projects.Commands.UpdateProject;
using TaskBoardManagementApp.Application.Features.Projects.Dtos;
using TaskBoardManagementApp.Domain.Entities;

namespace TaskBoardManagementApp.Application.Features.Projects.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreatedProjectDto, Project>().ReverseMap();
        CreateMap<UpdatedProjectDto, Project>().ReverseMap();
        CreateMap<UpdateProjectCommand, Project>().ReverseMap();
        CreateMap<ProjectGetByIdDto, Project>().ReverseMap();
        CreateMap<ProjectListDto, Project>().ReverseMap();
    }
}
