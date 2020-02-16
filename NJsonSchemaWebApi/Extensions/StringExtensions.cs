using Microsoft.AspNetCore.Mvc;

namespace NJsonSchemaWebApi.Extensions
{
    public static class StringExtensions
    {
        public static ContentResult ToJsonContentResult(this string s, int statusCode = 200)
        {
            return new ContentResult()
            {
                Content = s,
                ContentType = "application/json",
                StatusCode = statusCode
            };
        }

        public static ContentResult ToTextContentResult(this string s, int statusCode = 200)
        {
            return new ContentResult()
            {
                Content = s,
                ContentType = "text/plain",
                StatusCode = statusCode
            };
        }


    }
}
