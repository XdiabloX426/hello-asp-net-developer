using Acme.Hello.Platform.Generic.Domain.Model.Entities;
using Acme.Hello.Platform.Generic.Interfaces.REST.Resource;

namespace Acme.Hello.Platform.Generic.Interfaces.REST.Assemblers;

/// <summary>
/// This class is responsible for convert from REST resources to domain entities.
/// </summary>
public static class DeveloperAssembler
{
    /// <summary>
    /// Convert from GreetDeveloperRequest to Developer.
    /// </summary>
    /// <param name="request">The GreetDeveloperRequest request.</param>
    /// <returns>A Developer entity or null if the request is invalid.</returns>
    public static Developer? ToEntityFromRequest(GreetDeveloperRequest? request)
    {
        if (request == null || 
            string.IsNullOrWhiteSpace(request.FirstName) ||
            string.IsNullOrWhiteSpace(request.LastName))
        {
            return null;
        }
        return new Developer(request.FirstName, request.LastName);
    }
}