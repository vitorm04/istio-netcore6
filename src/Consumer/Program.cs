using Consumer;

var builder = WebApplication.CreateBuilder(args);
var a = builder.Configuration["HttpIntegration:BaseUrl"];
builder.Services.AddControllers();
builder.Services.AddHealthChecks();
builder.Services.AddLogging(x => x.ClearProviders().AddConsole());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient<Worker>("worker", options =>
{
    options.BaseAddress = new Uri(builder.Configuration["HttpIntegration:BaseUrl"]);
    options.Timeout = TimeSpan.FromSeconds(10);
});

builder.Services.AddHostedService<Worker>();

var app = builder.Build();
app.UseAuthorization();
app.MapHealthChecks("/health/live");
app.MapHealthChecks("/health/ready");
app.Run();
