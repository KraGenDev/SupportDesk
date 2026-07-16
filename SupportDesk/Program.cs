using SupportDesk.Api.Extentions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidators();
builder.Services.AddControllers();

var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
