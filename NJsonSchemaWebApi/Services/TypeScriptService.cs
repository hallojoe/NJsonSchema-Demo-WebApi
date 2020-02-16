using NJsonSchemaWebApi.Helpers;
using NJsonSchemaWebApi.Interfaces;

namespace NJsonSchemaWebApi.Services
{
    public class TypeScriptService: ITypeScriptService
    {

        private readonly ICSharpService _cSharpService;

        public TypeScriptService(ICSharpService cSharpService)
        {
            _cSharpService = cSharpService;
        }

        public string GetYamlSchema(string typeScript, string rootClassName) => _cSharpService.GetJsonSchema(GetCSharp(typeScript, rootClassName), rootClassName);

        public string GetJsonSchema(string typeScript, string rootClassName) => _cSharpService.GetJsonSchema(GetCSharp(typeScript, rootClassName), rootClassName);

        public string GetCSharp(string typeScript, string rootClassName) => CrappyTypeScriptToCSharpHelper.GetCSharp(typeScript);
    }
}
