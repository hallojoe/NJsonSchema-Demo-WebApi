using NJsonSchema.Yaml;
using NJsonSchemaWebApi.Interfaces;

namespace NJsonSchemaWebApi.Services
{
    public class YamlSchemaService : IYamlSchemaService
    {

        private readonly IJsonSchemaService _jsonSchemaService;

        public YamlSchemaService(IJsonSchemaService jsonSchemaService)
        {
            _jsonSchemaService = jsonSchemaService;
        }

        public string GetJsonSchema(string yamlSchema)
        {
            var schema = JsonSchemaYaml.FromYamlAsync(yamlSchema).GetAwaiter().GetResult();
            return schema.ToJson();
        }

        public string GetCSharp(string yamlSchema) => _jsonSchemaService.GetCSharp(GetJsonSchema(yamlSchema));

        public string GetTypeScript(string yamlSchema) => _jsonSchemaService.GetTypeScript(GetJsonSchema(yamlSchema));
    }
}
