using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Desafio.eclipseworks.TaskManager.Api.Configurations.Swagger
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
            }
        }

        public void Configure(string name, SwaggerGenOptions options)
        {
            Configure(options);
        }

        private OpenApiInfo CreateVersionInfo(ApiVersionDescription desc)
        {
            var info = new OpenApiInfo()
            {
                Title = "Desafio EclipseWorks Task Manager",
                Version = desc.ApiVersion.ToString(),
                Description = $"WebApi para alimentar o sistema de controle de tarefas v{Assembly.GetExecutingAssembly().GetName().Version}",
            };

            if (desc.IsDeprecated)
            {
                info.Description += "Endpoint depreciado. Pesquise e utilize a versão mais recente.";
            }

            return info;
        }
    }
}
