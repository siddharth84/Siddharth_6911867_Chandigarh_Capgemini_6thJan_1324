var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

// Register HttpClient
builder.Services.AddHttpClient("ProductApi", client =>
{
    client.BaseAddress = new Uri("http://localhost:5299/api/");
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();

app.Run();