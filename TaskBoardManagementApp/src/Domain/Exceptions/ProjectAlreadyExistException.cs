namespace TaskBoardManagementApp.Domain.Exceptions;

public class ProjectAlreadyExistException : Exception
{
    public ProjectAlreadyExistException(string project)
        : base(project)
    {

    }
}
