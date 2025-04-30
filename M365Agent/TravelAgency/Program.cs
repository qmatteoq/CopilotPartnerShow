using Microsoft.Agents.Builder;
using Microsoft.Agents.Hosting.AspNetCore;
using Microsoft.Agents.Storage;
using Microsoft.SemanticKernel;
using TravelAgency.Bots;
using TravelAgency.Agents;
using TravelAgency;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient();

builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddKernel();

builder.Services.AddAzureOpenAIChatCompletion(
       deploymentName: builder.Configuration.GetSection("AIServices:AzureOpenAI").GetValue<string>("DeploymentName"),
       endpoint: builder.Configuration.GetSection("AIServices:AzureOpenAI").GetValue<string>("Endpoint"),
       apiKey: builder.Configuration.GetSection("AIServices:AzureOpenAI").GetValue<string>("ApiKey"));

builder.Services.AddAgentAspNetAuthentication(builder.Configuration);
builder.AddAgentApplicationOptions();

builder.Services.AddTransient<TravelAgent>();
builder.AddAgent<BasicBot>();
builder.Services.AddSingleton<IStorage, MemoryStorage>();

var app = builder.Build();

app.UseRouting();
var root = app.MapPost("/api/messages", async (HttpRequest request, HttpResponse response, IAgentHttpAdapter adapter, IAgent agent, CancellationToken cancellationToken) =>
{
    await adapter.ProcessAsync(request, response, agent, cancellationToken);
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    root.AllowAnonymous();
    app.MapGet("/", () => "Microsoft 365 Agents SDK Sample");
    app.UseDeveloperExceptionPage();
}

app.Urls.Add($"http://localhost:3978");

app.Run();
