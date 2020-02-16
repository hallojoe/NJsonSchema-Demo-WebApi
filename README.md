# NJsonSchema-Demo-WebApi
A .NET core 3.1 WebApi using NJsonSchema for converting JSonSchema to C#, TypeScript. This demo focuses on translating JSonSchema, to C#, TypeScript and YamlSchema, but it also come with some very experimental support for translating C# and TypeScript into JsonSchema. 

When converting Json, JsonSchema and YamlSchema into C# or TypeScript, NJsonSchema is doing this. C# to TypeScript or JsonSchema is done with CS-Script, and converting TypeScript to C#, JsonSchema and YamlSchema, is done by horrible regex infected code - highly unstable. As of why, its called experimental.

## About

This demo came to life because of playing around with ideas on how frontend and backend teams could find common ground when passing view models to one another.

## Install and try

Clone repo, run solution in VS Code or VS 2019.

Postman FTW - In the root of the solution a Postman collection exist. It contains requests for all the endpoints in the soultion. Import to Postman and you are ready to try out the Api in no time.

## Endponts

`GET` `POST` `/api/json/json-schema`

`GET` `POST` `/api/json/csharp`

`GET` `POST` `/api/json/typescript`


`GET` `POST` `/api/json-schema/yaml-schema`

`GET` `POST` `/api/json-schema/csharp`

`GET` `POST` `/api/json-schema/typescript`


`GET` `POST` `/api/yaml-schema/yaml-schema`

`GET` `POST` `/api/yaml-schema/csharp`

`GET` `POST` `/api/yaml-schema/typescript`

### Experimental enpoints

`GET` `POST` `/api/csharp/typescript`

`GET` `POST` `/api/csharp/json-schema`

`GET` `POST` `/api/csharp/yaml-schema`


`GET` `POST` `/api/typescript/csharp`

`GET` `POST` `/api/typescript/json-schema`

`GET` `POST` `/api/typescript/yaml-schema`



