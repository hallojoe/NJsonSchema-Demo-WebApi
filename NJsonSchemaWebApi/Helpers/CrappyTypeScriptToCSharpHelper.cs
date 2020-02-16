using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NJsonSchemaWebApi.Helpers
{

    public static class CrappyTypeScriptToCSharpHelper
    { 
        private const string TypeScriptMultiCommentPattern = @"(\/\*(?:(?!\*\/).|[\n\r])*\*\/)";
        private const string TypeScriptSingleCommentPattern = @"/(\/\/[^\n\r]*[\n\r]+)";
        private const string TypeScriptInterfaceOrTypePattern = @".*(interface|type)\s([^\s]+)(?:[^\{]+)?(?:\{)([^\}]+)\}";
        private const string TypeScriptPropertyPatternPattern = @"[^\s\{{\}}][^{0}]+[{0}\}}\s]";
        private const string CSharpGetSet = "{ get; set; }";
        private const string CSharpListStart = "List<";
        private const string CSharpDictionaryStart = "Dictionary<";
        private const string CollectionEnd = ">";
        private const string CollectionEndAlt = "]";

        private static readonly Dictionary<string, string> TypeScriptKeyCSharpValue = new Dictionary<string, string>()
        {
            { "string", "string" },
            { "number", "int" },
            { "boolean", "bool" },
            { "object", "object" },
            { "Date", "DateTime" },
        };

        private static string GetCSharpType(string type)
        {
            if (!type.EndsWith(CollectionEnd) && !type.EndsWith(CollectionEndAlt))
                return TypeScriptKeyCSharpValue.ContainsKey(type) ? TypeScriptKeyCSharpValue[type] :  type;
            TranslateTypeScriptCollectionType(ref type);
            return type;
        }

        private static void RemoveMultiComments(ref string ts) => ts = Regex.Replace(ts, TypeScriptMultiCommentPattern, string.Empty);

        private static void RemoveSingleComments(ref string ts) => ts = Regex.Replace(ts, TypeScriptSingleCommentPattern, string.Empty);

        private static void TranslateTypeScriptCollectionType(ref string type)
        {
            if (type.EndsWith(CollectionEndAlt))
            {
                type = $"{CSharpListStart}{GetCSharpType(type.Substring(0, type.Length - 2))}{CollectionEnd}";
                return;
            }

            if (type.StartsWith("Array<"))
            {
                type = $"{CSharpListStart}{GetCSharpType(type.Replace("Array<", string.Empty).Trim('>'))}{CollectionEnd}";
                return;
            }

            if (!type.StartsWith("Map<")) return;

            var types = type.Replace("Map<", string.Empty).Trim('>').Split(',').Select(x => GetCSharpType(x.Trim())).ToList();
            
            if (types.Count != 2) return;

            type = $"{CSharpDictionaryStart}{types[0]}, {types[1]}{CollectionEnd}";

        }

        public static string GetCSharp(string ts)
        {

            RemoveMultiComments(ref ts);
            RemoveSingleComments(ref ts);

            var typeScriptInterfaceOrTypeMatcher = new Regex(TypeScriptInterfaceOrTypePattern,
                RegexOptions.IgnorePatternWhitespace);

            var matches = typeScriptInterfaceOrTypeMatcher.Matches(ts).ToList();

            if (matches.Count == 0) return string.Empty;

            var sb = new StringBuilder();

            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine();

            foreach (var match in matches)
            {
                var separator = match.Groups[1]?.Value?.Trim() == "interface" ? ";" : ",";
                var className = match.Groups[2]?.Value;
                var rawProperties = match.Groups[3].Value;

                var rawPropertyMatchPattern = string.Format(TypeScriptPropertyPatternPattern, separator);
                var rawPropertiesAsMatches = Regex.Matches(rawProperties, rawPropertyMatchPattern).ToList();

                sb.AppendLine($"public partial class {className} {Environment.NewLine}{{ ");

                foreach (var rawPropertyMatchValue in rawPropertiesAsMatches
                    .Select(rawPropertyMatch => rawPropertyMatch?.Value?.Trim(',', ';', '}', ' '))
                    .Where(rawPropertyMatchValue => rawPropertyMatchValue != null))
                {
                    if (!rawPropertyMatchValue.Contains(":"))
                    {
                        sb.AppendLine($"    object {rawPropertyMatchValue} {CSharpGetSet} ");
                        continue;
                    }

                    var splitValues = rawPropertyMatchValue.Split(':').Select(x => x.Trim()).ToList();
                    if(splitValues.Count != 2) continue;

                    var type = splitValues[1];
                    var name = splitValues[0];

                    var isNullable = name.EndsWith("?");

                    var cSharpType = GetCSharpType(type);

                    cSharpType = isNullable ? cSharpType + "?" : cSharpType;

                    sb.AppendLine($"    {cSharpType} {name} {CSharpGetSet} ");
                }
                sb.AppendLine("}");
            }
            sb.AppendLine();

            var s =  sb.ToString();

            return s;
        }


    }

}

