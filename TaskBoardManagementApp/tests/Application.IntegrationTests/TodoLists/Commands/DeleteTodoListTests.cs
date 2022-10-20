using FluentAssertions;
using NUnit.Framework;
using TaskBoardManagementApp.Application.Common.Exceptions;
using TaskBoardManagementApp.Application.TodoLists.Commands.CreateTodoList;
using TaskBoardManagementApp.Application.TodoLists.Commands.DeleteTodoList;
using TaskBoardManagementApp.Domain.Entities;

using static TaskBoardManagementApp.Application.IntegrationTests.Testing;

namespace TaskBoardManagementApp.Application.IntegrationTests.TodoLists.Commands;
public class DeleteTodoListTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidTodoListId()
    {
        var command = new DeleteTodoListCommand(99);
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteTodoList()
    {
        var listId = await SendAsync(new CreateTodoListCommand
        {
            Title = "New List"
        });

        await SendAsync(new DeleteTodoListCommand(listId));

        var list = await FindAsync<TodoList>(listId);

        list.Should().BeNull();
    }
}
