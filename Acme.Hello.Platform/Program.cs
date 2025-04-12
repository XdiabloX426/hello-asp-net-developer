using Acme.Hello.Platform.Generic.Domain.Model.Entities;
using Acme.Hello.Platform.Generic.Interfaces.REST.Assemblers;
using Acme.Hello.Platform.Generic.Interfaces.REST.Resource;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

/// <summary>
/// Define the GET endpoint for retrieving a gretting
/// </summary>
/// <param name="firstName">The first name of the developer</param>
/// <param name="lastName">The last name of the developer</param>
/// <returns>A greeting message</returns>
app.MapGet("/greetings", (string? firstName, string? lastName) =>
{
    var developer = !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName)
        ? new Developer(firstName, lastName)
        : null;
    var response = GreetDeveloperResponseAssembler.ToResponseFromEntity(developer);
    return Results.Ok(response);
}).WithName("GetGreetings").WithOpenApi();

/// <summary>
/// Define the POST endpoint for creating a greeting
/// </summary>
/// <param name="request">The request containing the developer's first and last name</param>
/// <returns>A response containing the greeting message</returns>
app.MapPost("/greetings", (GreetDeveloperRequest request) =>
{
    var developer = DeveloperAssembler.ToEntityFromRequest(request);
    var response = GreetDeveloperResponseAssembler.ToResponseFromEntity(developer);
    return Results.Created("/grettings", response);
}).WithName("CreateGreeting").WithOpenApi();

app.Run();
