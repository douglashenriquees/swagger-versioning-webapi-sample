using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace VersioningSample.WebApi.SwaggerFilters;

public class RemoveVersionFromParameter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var versionParameter = operation.Parameters.Single(x => x.Name == "version");
        operation.Parameters.Remove(versionParameter);
    }
}