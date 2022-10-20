using NUnit.Framework;

using static TaskBoardManagementApp.Application.IntegrationTests.Testing;

namespace TaskBoardManagementApp.Application.IntegrationTests;
[TestFixture]
public abstract class BaseTestFixture
{
    [SetUp]
    public async Task TestSetUp()
    {
        await ResetState();
    }
}
