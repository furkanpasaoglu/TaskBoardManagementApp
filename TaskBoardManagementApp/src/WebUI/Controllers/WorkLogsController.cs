using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using TaskBoardManagementApp.Application.Features.WorkLogs.Commands.CreateWorkLog;
using TaskBoardManagementApp.Application.Features.WorkLogs.Commands.DeleteWorkLog;
using TaskBoardManagementApp.Application.Features.WorkLogs.Commands.UpdateWorkLog;
using TaskBoardManagementApp.Application.Features.WorkLogs.Queries.GetByIdWorkLog;
using TaskBoardManagementApp.Application.Features.WorkLogs.Queries.GetListWorkLog;

namespace TaskBoardManagementApp.WebUI.Controllers;

[OpenApiTags("Work Logs")]
[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class WorkLogsController : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var result = await Mediator.Send(new GetListWorkLogQuery());
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var result = await Mediator.Send(new GetByIdWorkLogQuery{Id = id});
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateWorkLogCommand command)
    {
        var result = await Mediator.Send(command);
        return Created("", result);
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateWorkLogCommand command)
    {
        var result = await Mediator.Send(command);
        return Ok(result);
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteWorkLogCommand command)
    {
        var result = await Mediator.Send(command);
        return Ok(result);
    }
}