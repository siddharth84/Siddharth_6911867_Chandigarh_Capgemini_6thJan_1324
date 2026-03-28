using log4net;
using log4net.Config;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var repo = LogManager.GetRepository(Assembly.GetEntryAssembly());

var logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "log4net.config");

XmlConfigurator.Configure(repo, new FileInfo(logFilePath));

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseHttpsRedirection();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();