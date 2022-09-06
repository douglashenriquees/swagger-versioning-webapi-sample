using Microsoft.OpenApi.Models;
using VersioningSample.WebApi.SwaggerFilters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioning();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1.0", new OpenApiInfo
    {
        Version = "1.0",
        Title = "Sample API",
        Description = "Versioning Sample"
    });

    options.SwaggerDoc("v2.0", new OpenApiInfo()
    {
        Version = "2.0",
        Title = "Sample API",
        Description = "Versioning Sample"
    });

    options.OperationFilter<RemoveVersionFromParameter>();
    options.DocumentFilter<ReplaceVersionWithExactValueInPath>();
});

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(x =>
{
    x.RoutePrefix = "";
    x.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Sample API v1.0");
    x.SwaggerEndpoint("/swagger/v2.0/swagger.json", "Sample API v2.0");
});

app.Run();