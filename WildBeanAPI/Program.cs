using Microsoft.AspNetCore.RateLimiting;
using System.Net;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRateLimiter(rp => rp.AddFixedWindowLimiter(policyName: "ratePolicy", options =>
{
    options.AutoReplenishment = true;
    options.PermitLimit = 5;
    options.QueueLimit = 0;
    options.Window = TimeSpan.FromSeconds(10);
}).RejectionStatusCode = 503);

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

app.UseRateLimiter();

app.Run();
