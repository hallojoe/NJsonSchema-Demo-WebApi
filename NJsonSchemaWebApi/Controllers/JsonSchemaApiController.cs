using Microsoft.AspNetCore.Mvc;
using NJsonSchemaWebApi.Extensions;
using NJsonSchemaWebApi.Helpers;
using NJsonSchemaWebApi.Interfaces;

namespace NJsonSchemaWebApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class JsonSchemaApiController : ControllerBase
    {

        private readonly IJsonSchemaService _jsonSchemaService;

        public JsonSchemaApiController(IJsonSchemaService jsonSchemaService)
        {
            _jsonSchemaService = jsonSchemaService;
        }

        [HttpGet]
        [Route("json-schema/csharp")]
        public ContentResult JsonSchemaToCSharp() =>
            _jsonSchemaService.GetCSharp(Constants.DefaultJsonSchemaInputValue).ToJsonContentResult();

        [HttpPost]
        [Route("json-schema/csharp")]
        public ContentResult JsonSchemaToCSharp(object o) =>
            _jsonSchemaService.GetCSharp(o.ToString()).ToJsonContentResult();

        [HttpGet]
        [Route("json-schema/typescript")]
        public ContentResult JsonSchemaToTypeScript() => 
            _jsonSchemaService.GetTypeScript(Constants.DefaultJsonSchemaInputValue).ToJsonContentResult();

        [HttpPost]
        [Route("json-schema/typescript")]
        public ContentResult JsonSchemaToTypeScript(object o) =>
            _jsonSchemaService.GetTypeScript(o.ToString()).ToJsonContentResult();


        [HttpGet]
        [Route("json-schema/yaml-schema")]
        public ContentResult JsonSchemaToYamlSchema() =>
            _jsonSchemaService.GetYamlSchema(Constants.DefaultJsonSchemaInputValue).ToJsonContentResult();

        [HttpPost]
        [Route("json-schema/yaml-schema")]
        public ContentResult JsonSchemaToYamlSchema(object o) =>
            _jsonSchemaService.GetYamlSchema(o.ToString()).ToJsonContentResult();




    }
}
