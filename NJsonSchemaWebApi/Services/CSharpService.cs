using CSScriptLib;
using NJsonSchema;
using NJsonSchema.Yaml;
using NJsonSchemaWebApi.Interfaces;

namespace NJsonSchemaWebApi.Services
{
    public class CSharpService : ICSharpService
    {
        private readonly IJsonSchemaService _jsonSchemaService;

        public CSharpService(IJsonSchemaService jsonSchemaService)
        {
            _jsonSchemaService = jsonSchemaService;
        }

        public string GetJsonSchema(string cSharp, string rootClassName)
        {
            var model = CompileCSharpAndCreateObject(cSharp, rootClassName);
            var schema = JsonSchema.FromType(model.GetType());
            return schema.ToJson();
        }

        public string GetYamlSchema(string cSharp, string rootClassName)
        {
            var model = CompileCSharpAndCreateObject(cSharp, rootClassName);
            var schema = JsonSchema.FromType(model.GetType());
            return schema.ToYaml();
        }

        public string GetTypeScript(string cs, string rootClassName) => _jsonSchemaService.GetTypeScript(GetJsonSchema(cs, rootClassName));

        private static object CompileCSharpAndCreateObject(string cSharp, string rootClassName) =>
            CSScript.Evaluator.CompileCode(cSharp).CreateObject(rootClassName);

    }
}
