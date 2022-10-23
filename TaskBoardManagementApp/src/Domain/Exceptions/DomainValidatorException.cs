namespace TaskBoardManagementApp.Domain.Exceptions;

public class DomainValidatorException : Exception
{
    public DomainValidatorException(string message) 
        :base (message)
    {

    }
}
