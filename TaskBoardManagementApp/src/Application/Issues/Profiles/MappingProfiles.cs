using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
