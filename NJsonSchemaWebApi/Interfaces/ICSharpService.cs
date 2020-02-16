namespace NJsonSchemaWebApi.Interfaces
{
    public interface ICSharpService
    {
        string GetJsonSchema(string cSharp, string rootClassName);
        string GetTypeScript(string cSharp, string rootClassName);
        string GetYamlSchema(string cSharp, string rootClassName);
    }
}
