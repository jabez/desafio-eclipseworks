using Desafio.eclipseworks.TaskManager.Api.Configurations.Swagger;
using Desafio.eclipseworks.TaskManager.Api.Middlewares;
using Desafio.eclipseworks.TaskManager.Infra.CrossCutting.Ioc;
using Desafio.EclipseWorks.TaskManager.Api.Configurations.DataBase;
using Desafio.EclipseWorks.TaskManager.Api.Filters;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        opt.JsonSerializerOptions.WriteIndented = true;
        opt.JsonSerializerOptions.PropertyNameCaseInsensitive = true;

    });

builder.Services.AddMyDependencies();
builder.Services.AddMySwagger();
builder.Services.AddMyDatabaseExtension(builder.Configuration);
builder.Services.AddScoped<AcessoGerencialFilter>();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseMySwagger();

app.UseMyMigrations();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
