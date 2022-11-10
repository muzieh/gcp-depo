using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using WebApplication2;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((ctx, lc) => lc
    //.WriteTo.Console(new JsonFormatter())
    .WriteTo.Console()
    .WriteTo.Seq("http://seq:5341")
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<IForecastClient, ForecastClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();