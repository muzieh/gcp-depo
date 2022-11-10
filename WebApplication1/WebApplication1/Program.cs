using System.Text.Json;
using System.Text.Json.Serialization;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;

Log.Logger = new LoggerConfiguration()
    //.WriteTo.Console(new JsonFormatter())
    .WriteTo.Console()
    .WriteTo.Seq("http://seq:5341")
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Debug)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((ctx, lc) => lc
    //.WriteTo.Console(new JsonFormatter())
    .WriteTo.Console()
    .WriteTo.Seq("http://seq:5341")
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Debug)
);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();