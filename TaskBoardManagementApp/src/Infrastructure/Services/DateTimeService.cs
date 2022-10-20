using TaskBoardManagementApp.Application.Common.Interfaces;

namespace TaskBoardManagementApp.Infrastructure.Services;
public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
