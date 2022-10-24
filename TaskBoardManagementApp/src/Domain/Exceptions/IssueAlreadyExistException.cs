namespace TaskBoardManagementApp.Domain.Exceptions;

public class IssueAlreadyExistException : Exception
{
    public IssueAlreadyExistException(string issue) 
        : base(issue)
    {

    }
}
