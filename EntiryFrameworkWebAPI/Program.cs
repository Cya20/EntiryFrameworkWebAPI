using EntiryFrameworkWebAPI;
using EntiryFrameworkWebAPI.BLL.Interfaces;
using EntiryFrameworkWebAPI.BLL.Service;
using EntiryFrameworkWebAPI.DAL.Data;
using EntiryFrameworkWebAPI.DAL.IRepository;
using EntiryFrameworkWebAPI.DAL.Repository;
using EntiryFrameworkWebAPI.Interface;
using EntiryFrameworkWebAPI.Middleware;
using EntiryFrameworkWebAPI.Security;
using EntiryFrameworkWebAPI.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<ApiKeyAuthFilter>();
builder.Services.AddScoped<IApiKeyValidation, ApiKeyValidation>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "EntiryFrameworkWebAPI", Version = "v1" });

    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "API Key needed to access the endpoints. Add 'X-API-KEY' as the key",
        In = ParameterLocation.Header,
        Name = "X-API-KEY",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "ApiKeyScheme"
    });


    c.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("ApiKey", document)] = []
    });


});

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
});

builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductBusinessLogic, ProductBusinessLogicService>();
builder.Services.AddSingleton<ILoggerService, LoggerService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ApiRequestFlowMiddleware>();

app.MapControllers();

app.Run();
