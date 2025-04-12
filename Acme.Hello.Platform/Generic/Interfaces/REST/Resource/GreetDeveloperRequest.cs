namespace Acme.Hello.Platform.Generic.Interfaces.REST.Resource;

/// <summary>
/// This is a request to greet a developer, used as input for the greeting request.
/// </summary>
/// <param name="FirstName">The first name of the developer. Can be null</param>
/// <param name="LastName">The last name of the developer. Can be null</param>
public record GreetDeveloperRequest(string? FirstName, string? LastName);