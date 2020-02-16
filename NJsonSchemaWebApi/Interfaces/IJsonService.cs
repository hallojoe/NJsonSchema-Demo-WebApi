namespace NJsonSchemaWebApi.Interfaces
{
    public interface IJsonService
    {
        string GetJsonSchema(string json);
        string GetCSharp(string json);
        string GetTypeScript(string json);
        string GetYamlSchema(string json);
    }
}
