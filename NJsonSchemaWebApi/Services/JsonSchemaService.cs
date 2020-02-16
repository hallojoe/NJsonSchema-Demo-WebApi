using NJsonSchema;
using NJsonSchema.CodeGeneration.CSharp;
using NJsonSchema.CodeGeneration.TypeScript;
using NJsonSchema.Yaml;
using NJsonSchemaWebApi.Interfaces;

namespace NJsonSchemaWebApi.Services
{
    public class JsonSchemaService : IJsonSchemaService
    {
        public string GetCSharp(string jsonSchema)
        {
            var schema = JsonSchema.FromJsonAsync(jsonSchema).GetAwaiter().GetResult();
            var settings = new CSharpGeneratorSettings();
            var generator = new CSharpGenerator(schema, settings);
            var code = generator.GenerateFile();
            return code;
        }
        
        public string GetYamlSchema(string jsonSchema) =>
            JsonSchema.FromJsonAsync(jsonSchema).GetAwaiter().GetResult().ToYaml();

        public string GetTypeScript(string jsonSchema)
        {
            var schema = JsonSchema.FromJsonAsync(jsonSchema).GetAwaiter().GetResult();
            var generator = new TypeScriptGenerator(schema,
                new TypeScriptGeneratorSettings
                {
                    TypeStyle = TypeScriptTypeStyle.Interface,
                    TypeScriptVersion = 2.0m
                });
            var code = generator.GenerateFile();
            return code;
        }

    }
}
