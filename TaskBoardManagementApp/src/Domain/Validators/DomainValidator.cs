namespace TaskBoardManagementApp.Domain.Validators;

public static class DomainValidator
{
    public static string CheckNotNull(string data)
    {
        if (data is null)
            throw new DomainValidatorException($"{data} is null!");

        return data;
    }

    public static T CheckNotNull<T>(T data)
    {
        if(data == null)
            throw new DomainValidatorException($"{data} is null!");

        return data;
    }

    public static string CheckNotNullOrWhiteSpace(string data)
    {
        if(String.IsNullOrWhiteSpace(data))
            throw new DomainValidatorException($"{data} is null or include white space!");

        return data;
    }
}
