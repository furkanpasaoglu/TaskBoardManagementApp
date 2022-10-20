using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskBoardManagementApp.Application.Common.Models;
using TaskBoardManagementApp.Application.TodoItems.Commands.CreateTodoItem;
using TaskBoardManagementApp.Application.TodoItems.Commands.DeleteTodoItem;
using TaskBoardManagementApp.Application.TodoItems.Commands.UpdateTodoItem;
using TaskBoardManagementApp.Application.TodoItems.Commands.UpdateTodoItemDetail;
using TaskBoardManagementApp.Application.TodoItems.Queries.GetTodoItemsWithPagination;

namespace TaskBoardManagementApp.WebUI.Controllers;
[Authorize]
public class TodoItemsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<TodoItemBriefDto>>> GetTodoItemsWithPagination([FromQuery] GetTodoItemsWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateTodoItemCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateTodoItemCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpPut("[action]")]
    public async Task<ActionResult> UpdateItemDetails(int id, UpdateTodoItemDetailCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteTodoItemCommand(id));

        return NoContent();
    }
}
