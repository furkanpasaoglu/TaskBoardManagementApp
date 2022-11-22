using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using TaskBoardManagementApp.Application.Features.Projects.Commands.CreateProject;
using TaskBoardManagementApp.Application.Features.Projects.Commands.DeleteProject;
using TaskBoardManagementApp.Application.Features.Projects.Commands.UpdateProject;
using TaskBoardManagementApp.Application.Features.Projects.Queries.GetByIdProject;
using TaskBoardManagementApp.Application.Features.Projects.Queries.GetListProject;

namespace TaskBoardManagementApp.WebUI.Controllers;

[OpenApiTags("Projects")]
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProjectsController : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var result = await Mediator.Send(new GetListProjectQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var result = await Mediator.Send(new GetByIdProjectQuery() { Id = id });
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProjectCommand command)
    {
        var result = await Mediator.Send(command);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProjectCommand command)
    {
        var result = await Mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteProjectCommand command)
    {
        var result = await Mediator.Send(command);
        return Ok(result);
    }
}
