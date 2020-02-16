namespace NJsonSchemaWebApi.Interfaces
{
    public interface ITypeScriptService
    {
        string GetJsonSchema(string typeScript, string rootClassName);
        string GetCSharp(string typeScript, string rootClassName);
        string GetYamlSchema(string typeScript, string rootClassName);
    }
}
