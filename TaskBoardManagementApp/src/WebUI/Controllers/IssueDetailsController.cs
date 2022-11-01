using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using TaskBoardManagementApp.Application.Features.IssueDetails.Commands.CreateIssueDetail;
using TaskBoardManagementApp.Application.Features.IssueDetails.Commands.DeleteIssueDetail;
using TaskBoardManagementApp.Application.Features.IssueDetails.Commands.UpdateIssueDetail;
using TaskBoardManagementApp.Application.Features.IssueDetails.Queries.GetByIdIssueDetail;
using TaskBoardManagementApp.Application.Features.IssueDetails.Queries.GetListIssueDetail;

namespace TaskBoardManagementApp.WebUI.Controllers;

[OpenApiTags("Issue Details")]
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class IssueDetailsController : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var result = await Mediator.Send(new GetListIssueDetailQuery());
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var result = await Mediator.Send(new GetByIdIssueDetailQuery() { Id = id });
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateIssueDetailCommand command)
    {
        var result = await Mediator.Send(command);
        return Created("", result);
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateIssueDetailCommand command)
    {
        var result = await Mediator.Send(command);
        return Ok(result);
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteIssueDetailCommand command)
    {
        var result = await Mediator.Send(command);
        return Ok(result);
    }
}