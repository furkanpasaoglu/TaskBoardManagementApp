using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using TaskBoardManagementApp.Application.Common.Behaviours;
using TaskBoardManagementApp.Application.Common.Interfaces;

namespace TaskBoardManagementApp.Application.UnitTests.Common.Behaviours;
public class RequestLoggerTests
{
    private Mock<ICurrentUserService> _currentUserService = null!;
    private Mock<IIdentityService> _identityService = null!;

    [SetUp]
    public void Setup()
    {
        _currentUserService = new Mock<ICurrentUserService>();
        _identityService = new Mock<IIdentityService>();
    }
}
