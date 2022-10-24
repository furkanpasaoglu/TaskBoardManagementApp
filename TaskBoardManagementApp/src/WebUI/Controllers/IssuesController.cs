using Microsoft.AspNetCore.Mvc;
using TaskBoardManagementApp.Application.Issues.Commands.CreateIssue;
using TaskBoardManagementApp.Application.Issues.Commands.DeleteIssue;
using TaskBoardManagementApp.Application.Issues.Commands.UpdateIssue;

namespace TaskBoardManagementApp.WebUI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IssuesController : ApiControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateIssueCommand command)
    {
        var result = await Mediator.Send(command);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateIssueCommand command)
    {
        var result = await Mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteIssueCommand command)
    {
        var result = await Mediator.Send(command);
        return Ok(result);
    }
}
