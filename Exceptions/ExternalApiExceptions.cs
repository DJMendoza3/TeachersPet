namespace TeachersPet.Exceptions;

public class OpenAIException : Exception
{
    public OpenAIException()
    {
    }

    public OpenAIException(string message)
        : base(message)
    {
    }

    public OpenAIException(string message, Exception inner)
        : base(message, inner)
    {
    }
}

public class OpenAIParseException : OpenAIException
{
    public OpenAIParseException()
    {
    }

    public OpenAIParseException(string message)
        : base(message)
    {
    }

    public OpenAIParseException(string message, Exception inner)
        : base(message, inner)
    {
    }
}