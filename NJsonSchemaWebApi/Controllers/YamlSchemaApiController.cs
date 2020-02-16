using System.IO;
using Microsoft.AspNetCore.Mvc;
using NJsonSchemaWebApi.Extensions;
using NJsonSchemaWebApi.Helpers;
using NJsonSchemaWebApi.Interfaces;

namespace NJsonSchemaWebApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class YamlSchemaApiController : ControllerBase
    {

        private readonly IYamlSchemaService _yamlSchemaService;

        public YamlSchemaApiController(IYamlSchemaService yamlSchemaService)
        {
            _yamlSchemaService = yamlSchemaService;
        }

        [HttpGet]
        [Route("yaml-schema/json-schema")]
        public ContentResult YamlSchemaToJsonSchema()
        {
            return _yamlSchemaService.GetJsonSchema(Constants.DefaultYamlInputValue).ToJsonContentResult();
        }

        [HttpPost]
        [Consumes("text/plain")]
        [Produces("text/plain")]
        [Route("yaml-schema/json-schema")]
        public ContentResult YamlSchemaToJsonSchemaFromBody()
        {
            using var reader = new StreamReader(Request.Body);
            var yamlSchema = reader.ReadToEndAsync();
            return _yamlSchemaService.GetJsonSchema(yamlSchema.GetAwaiter().GetResult()).ToJsonContentResult();
        }

        [HttpGet]
        [Route("yaml-schema/csharp")]
        public ContentResult YamlToCSharp()
        {
            return _yamlSchemaService.GetCSharp(Constants.DefaultYamlInputValue).ToJsonContentResult();
        }

        [HttpPost]
        [Consumes("text/plain")]
        [Produces("text/plain")]
        [Route("yaml-schema/csharp")]
        public ContentResult YamlSchemaToCSharpFromBody()
        {
            using var reader = new StreamReader(Request.Body);
            var yamlSchema = reader.ReadToEndAsync();
            return _yamlSchemaService.GetCSharp(yamlSchema.GetAwaiter().GetResult()).ToJsonContentResult();
        }

        [HttpGet]
        [Route("yaml-schema/typescript")]
        public ContentResult YamlToTypeScript()
        {
            return _yamlSchemaService.GetTypeScript(Constants.DefaultYamlInputValue).ToJsonContentResult();
        }

        [HttpPost]
        [Consumes("text/plain")]
        [Produces("text/plain")]
        [Route("yaml-schema/typescript")]
        public ContentResult YamlSchemaToTypeScriptFromBody()
        {
            using var reader = new StreamReader(Request.Body);
            var yamlSchema = reader.ReadToEndAsync();
            return _yamlSchemaService.GetTypeScript(yamlSchema.GetAwaiter().GetResult()).ToJsonContentResult();
        }


    }
}
