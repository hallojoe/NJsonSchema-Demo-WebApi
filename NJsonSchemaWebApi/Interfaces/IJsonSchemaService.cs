namespace NJsonSchemaWebApi.Interfaces
{
    public interface IJsonSchemaService
    {
        string GetCSharp(string jsonSchema);
        string GetTypeScript(string jsonSchema);
        string GetYamlSchema(string jsonSchema);
    }
}
