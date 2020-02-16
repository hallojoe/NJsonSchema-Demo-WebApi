using System.IO;
using Microsoft.AspNetCore.Mvc;
using NJsonSchemaWebApi.Extensions;
using NJsonSchemaWebApi.Helpers;
using NJsonSchemaWebApi.Interfaces;

namespace NJsonSchemaWebApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class TypeScriptApiController : ControllerBase
    {

        private readonly ITypeScriptService _typeScriptService;

        public TypeScriptApiController(ITypeScriptService typeScriptService)
        {
            _typeScriptService = typeScriptService;
        }

        [HttpGet]
        [Route("typescript/json-schema")]
        public ContentResult TypeScriptToJsonSchema()
        {
            return _typeScriptService.GetJsonSchema(Constants.DefaultTypeScriptInputValue, "Model").ToJsonContentResult();
        }

        [HttpGet]
        [Route("typescript/csharp")]
        public ContentResult TypeScriptToCSharp()
        {
            return _typeScriptService.GetCSharp(Constants.DefaultTypeScriptInputValue, "Model").ToJsonContentResult();
        }

        [HttpGet]
        [Route("typescript/yaml-schema")]
        public ContentResult TypeScriptToYamlSchema()
        {
            return _typeScriptService.GetYamlSchema(Constants.DefaultTypeScriptInputValue, "Model").ToJsonContentResult();
        }

        [HttpPost]
        [Consumes("text/plain")]
        [Produces("text/plain")]
        [Route("typescript/json-schema")]
        public ContentResult TypeScriptToJsonSchemaFromBody()
        {
            using var reader = new StreamReader(Request.Body);
            var typeScript = reader.ReadToEndAsync();
            var code = _typeScriptService.GetJsonSchema(typeScript.GetAwaiter().GetResult(), "Model");
            return code.ToTextContentResult();
        }

        [HttpPost]
        [Consumes("text/plain")]
        [Produces("text/plain")]
        [Route("typescript/csharp")]
        public ContentResult TypeScriptToCSharpFromBody()
        {
            using var reader = new StreamReader(Request.Body);
            var typeScript = reader.ReadToEndAsync();
            var code = _typeScriptService.GetCSharp(typeScript.GetAwaiter().GetResult(), "Model");
            return code.ToTextContentResult();
        }

        [HttpPost]
        [Consumes("text/plain")]
        [Produces("text/plain")]
        [Route("typescript/yaml-schema")]
        public ContentResult TypeScriptToYamlSchemaFromBody()
        {
            using var reader = new StreamReader(Request.Body);
            var typeScript = reader.ReadToEndAsync();
            var code = _typeScriptService.GetYamlSchema(typeScript.GetAwaiter().GetResult(), "Model");
            return code.ToTextContentResult();
        }


    }
}
