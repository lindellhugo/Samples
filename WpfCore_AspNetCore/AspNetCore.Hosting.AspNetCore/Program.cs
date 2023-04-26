using OpenRiaServices.Hosting.AspNetCore;
using SimpleApplication.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenRiaServices();
builder.Services.AddTransient<SampleDomainService>();

var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.MapOpenRiaServices(builder =>
{
	builder.AddDomainService(typeof(SampleDomainService));
});

app.Run();
