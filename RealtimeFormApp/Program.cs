using Azure.AI.OpenAI;
using System.ClientModel;
using RealtimeFormApp.Components;
using OpenAI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents(o => o.DetailedErrors = true);

// -----------------------------------------------------------------------------------
// Using Ollama with OpenAI compatibility layer
var openAiClient = new OpenAIClient(new OpenAIClientOptions
{
    BaseAddress = new Uri("http://localhost:11434/v1"), // Ollama API endpoint
    ApiKey = "ollama" // required but unused for Ollama
});

// Configure the realtime client to use local Ollama model
var realtimeClient = openAiClient.GetRealtimeConversationClient("llama2"); // 或其他你想使用的模型
builder.Services.AddSingleton(realtimeClient);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
