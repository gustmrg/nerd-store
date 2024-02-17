using NSE.WebApp.MVC.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityConfiguration();
builder.Services.AddAppConfiguration();

var app = builder.Build();

app.UseAppConfiguration(app.Environment);

app.Run();