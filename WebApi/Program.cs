using Application;
using ExternalServices.Outlook.Interface;
using ExternalServices.Outlook.Services;
using FluentValidation;
using MediatR;
using Microsoft.OpenApi.Models;
using System.Reflection;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();
builder.Services.AddTransient<IEventService, EventService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        corsbuilder => corsbuilder.WithOrigins("https://localhost:44444")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddApplicationLayer();
builder.Services.AddApiVersioningExtension();
builder.Services.AddControllers();

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddValidatorsFromAssembly(System.Reflection.Assembly.Load("Application"));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();