using Microsoft.AspNetCore.Mvc;
using NJsonSchemaWebApi.Extensions;
using NJsonSchemaWebApi.Helpers;
using NJsonSchemaWebApi.Interfaces;

namespace NJsonSchemaWebApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class JsonApiController : ControllerBase
    {

        private readonly IJsonService _jsonService;

        public JsonApiController(IJsonService jsonService)
        {
            _jsonService = jsonService;
        }

        [HttpGet]
        [Route("json/json-schema")]
        public ContentResult JsonToJsonSchema() => _jsonService.GetJsonSchema(Constants.DefaultJsonInputValue).ToJsonContentResult();

        [HttpPost]
        [Route("json/json-schema")]
        public ContentResult JsonToSchema(object o) => _jsonService.GetJsonSchema(o.ToString()).ToJsonContentResult();

        [HttpGet]
        [Route("json/csharp")]
        public ContentResult JsonToCSharp() => _jsonService.GetCSharp(Constants.DefaultJsonInputValue).ToJsonContentResult();

        [HttpPost]
        [Route("json/csharp")]
        public ContentResult JsonToCSharp(object o) => _jsonService.GetCSharp(o.ToString()).ToJsonContentResult();

        [HttpGet]
        [Route("json/typescript")]
        public ContentResult JsonToTypeScript() => _jsonService.GetTypeScript(Constants.DefaultJsonInputValue).ToJsonContentResult();

        [HttpPost]
        [Route("json/typescript")]
        public ContentResult JsonToTypeScript(object o) => _jsonService.GetTypeScript(o.ToString()).ToJsonContentResult();



    }
}
