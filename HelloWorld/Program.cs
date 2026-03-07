using GreeterLib;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

// Create DI container
var services = new ServiceCollection();

// Register services
services.AddSingleton<IGreeter, Greeter>();

// Build provider
var serviceProvider = services.BuildServiceProvider();

// Resolve dependency
var greeter = serviceProvider.GetRequiredService<IGreeter>();

var data = new
{
    Message = greeter.Greet("Dependency Injection"),
    Time = DateTime.Now
};

string json = JsonConvert.SerializeObject(data);

Console.WriteLine(json);



