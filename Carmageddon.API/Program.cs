using Microsoft.AspNetCore.Builder;
using Microsoft.Owin.Cors;
using Microsoft.AspNetCore.SignalR;
using Carmageddon.API.Hubs;
using Carmageddon.API.Strategy;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapHub<ConnectionHub>("/current-time");
app.MapHub<BattleHub>("/battle");
app.UseAuthorization();

app.MapControllers();

app.Run();
