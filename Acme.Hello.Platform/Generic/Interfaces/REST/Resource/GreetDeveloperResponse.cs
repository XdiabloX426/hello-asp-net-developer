namespace Acme.Hello.Platform.Generic.Interfaces.REST.Resource;

/// <summary>
/// This is a response to greet a developer. It contains the developer's id, full name, and a message.
/// It is used as output for the greeting request.
/// </summary>
/// <param name="id">The id of the developer. Can be null</param>
/// <param name="FullName">The full name of the developer. Can be null</param>
/// <param name="Message">The greeting message. This is a required field</param>
public record GreetDeveloperResponse(Guid? id, string? FullName, string Message)
{
    /// <summary>
    /// This constructor is used to create a GreetDeveloperResponse with only the message.
    /// </summary>
    /// <param name="Message"></param>
    public GreetDeveloperResponse(string Message) : this(null, null, Message)
    {
        
    }
}