using System.IO;
using Microsoft.AspNetCore.Mvc;
using NJsonSchemaWebApi.Extensions;
using NJsonSchemaWebApi.Helpers;
using NJsonSchemaWebApi.Interfaces;

namespace NJsonSchemaWebApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class CSharpApiController : ControllerBase
    {

        private readonly ICSharpService _cSharpService;

        public CSharpApiController(ICSharpService cSharpService)
        {
            _cSharpService = cSharpService;
        }

        [HttpGet]
        [Route("csharp/json-schema")]
        public ContentResult CSharpToJsonSchema()
        {
            return _cSharpService.GetJsonSchema(Constants.DefaultCSharpInputValue, "Model").ToJsonContentResult();
        }

        [HttpPost]
        [Consumes("text/plain")]
        [Produces("text/plain")]
        [Route("csharp/json-schema")]
        public ContentResult CSharpToJsonSchemaFromBody()
        {
            using var reader = new StreamReader(Request.Body);
            var cSharp = reader.ReadToEndAsync();
            var code = _cSharpService.GetJsonSchema(cSharp.GetAwaiter().GetResult(), "Model");
            return code.ToTextContentResult();
        }

        [HttpGet]
        [Route("csharp/yaml-schema")]
        public ContentResult CSharpToYamlSchema()
        {
            return _cSharpService.GetYamlSchema(Constants.DefaultCSharpInputValue, "Model").ToJsonContentResult();
        }

        [HttpPost]
        [Consumes("text/plain")]
        [Produces("text/plain")]
        [Route("csharp/yaml-schema")]
        public ContentResult CSharpToYamlSchemaFromBody()
        {
            using var reader = new StreamReader(Request.Body);
            var cSharp = reader.ReadToEndAsync();
            var code = _cSharpService.GetYamlSchema(cSharp.GetAwaiter().GetResult(), "Model");
            return code.ToTextContentResult();
        }


        [HttpGet]
        [Route("csharp/typescript")]
        public ContentResult CSharpToTypeScript()
        {
            return _cSharpService.GetTypeScript(Constants.DefaultCSharpInputValue, "Model").ToJsonContentResult();
        }

        [HttpPost]
        [Consumes("text/plain")]
        [Produces("text/plain")]
        [Route("csharp/typescript")]
        public ContentResult CSharpToTypeScriptFromBody()
        {
            using var reader = new StreamReader(Request.Body);
            var cSharp = reader.ReadToEndAsync();
            var code = _cSharpService.GetTypeScript(cSharp.GetAwaiter().GetResult(), "Model");
            return code.ToTextContentResult();
        }



    }
}
