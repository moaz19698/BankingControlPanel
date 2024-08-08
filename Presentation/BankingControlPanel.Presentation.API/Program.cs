using BankingControlPanel.Application.Clients.Validators;
using BankingControlPanel.Application.Extensions;
using BankingControlPanel.Infrastructure.Extensions;
using BankingControlPanel.Infrastructure.Persistence.Sql.Data;
using BankingControlPanel.Presentation.API.Extensions;
using BankingControlPanel.Presentation.API.Filters;
using BankingControlPanel.Presentation.API.Middlewares;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers(options =>
{
    options.Filters.Add<ApiExceptionFilter>(); // Global exception filter
}).AddFluentValidation(fv =>
{
    fv.RegisterValidatorsFromAssemblyContaining<CreateClientValidator>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddAPIPresentation(builder.Configuration);
// Register MediatR
//builder.Services.AddMediatR(typeof(Program).Assembly);
var app = builder.Build();
// Configure the HTTP request pipeline
app.UseMiddleware<JwtMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
