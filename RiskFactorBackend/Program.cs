using RiskFactorBackend;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

var symptomBank = new SymptomBank();
var generateDay = new GenerateDay(symptomBank);

app.MapGet("/api/message", (HttpRequest req) =>
{
    var dayQuery = req.Query["day"].FirstOrDefault();
    int Day = 1;
    if (!string.IsNullOrEmpty(dayQuery) && int.TryParse(dayQuery, out var parsedDay))
    {
        Day = parsedDay;
    }
    return generateDay.Symptoms(Day);
});

app.MapGet("/api/dayinfo", (HttpRequest req) => {
    var dayQuery = req.Query["day"].FirstOrDefault();
    int Day = 1;
    if (!string.IsNullOrEmpty(dayQuery) && int.TryParse(dayQuery, out var parsedDay)) {
        Day = parsedDay;
    }
    return Results.Text(generateDay.DayInfo(Day));
});

app.Run();