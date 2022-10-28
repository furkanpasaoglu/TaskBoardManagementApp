using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using TaskBoardManagementApp.Application.Comments.Commands.CreateComment;
using TaskBoardManagementApp.Application.Comments.Commands.DeleteComment;
using TaskBoardManagementApp.Application.Comments.Commands.UpdateComment;
using TaskBoardManagementApp.Application.Comments.Queries.GetByIdComment;
using TaskBoardManagementApp.Application.Comments.Queries.GetListComments;

namespace TaskBoardManagementApp.WebUI.Controllers;

[OpenApiTags("Comments")]
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CommentsController : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var result = await Mediator.Send(new GetListCommentQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var result = await Mediator.Send(new GetByIdCommentQuery() { Id = id });
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCommentCommand command)
    {
        var result = await Mediator.Send(command);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCommentCommand command)
    {
        var result = await Mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteCommentCommand command)
    {
        var result = await Mediator.Send(command);
        return Ok(result);
    }
}
