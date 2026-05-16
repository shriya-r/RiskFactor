var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/api/message", () =>
{
    return new { text = "Hello from backend" };
});

app.Run();