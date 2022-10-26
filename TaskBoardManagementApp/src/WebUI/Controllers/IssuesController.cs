using Microsoft.AspNetCore.Mvc;
using TaskBoardManagementApp.Application.Issues.Commands.CreateIssue;
using TaskBoardManagementApp.Application.Issues.Commands.DeleteIssue;
using TaskBoardManagementApp.Application.Issues.Commands.UpdateIssue;
using TaskBoardManagementApp.Application.Issues.Queries.GetByIdIssue;
using TaskBoardManagementApp.Application.Issues.Queries.GetListIssues;

namespace TaskBoardManagementApp.WebUI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IssuesController : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var result = await Mediator.Send(new GetListIssueQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var result = await Mediator.Send(new GetByIdIssueQuery() { Id = id });
        return Ok(result);
    }

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
