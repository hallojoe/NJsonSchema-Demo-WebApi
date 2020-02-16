namespace NJsonSchemaWebApi.Interfaces
{
    public interface IYamlSchemaService
    {
        string GetJsonSchema(string yamlSchema);
        string GetCSharp(string yamlSchema);
        string GetTypeScript(string yamlSchema);
    }
}
