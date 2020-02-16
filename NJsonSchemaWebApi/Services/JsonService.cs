using NJsonSchema;
using NJsonSchemaWebApi.Interfaces;

namespace NJsonSchemaWebApi.Services
{
    public class JsonService : IJsonService
    {
        private readonly IJsonSchemaService _jsonSchemaService;

        public JsonService(IJsonSchemaService jsonSchemaService)
        {
            _jsonSchemaService = jsonSchemaService;
        }

        public string GetJsonSchema(string json) => JsonSchema.FromSampleJson(json).ToJson();
        
        public string GetCSharp(string json) => _jsonSchemaService.GetCSharp(GetJsonSchema(json));

        public string GetTypeScript(string json) => _jsonSchemaService.GetTypeScript(GetJsonSchema(json));

        public string GetYamlSchema(string json) => _jsonSchemaService.GetYamlSchema(GetJsonSchema(json));
    }
}
