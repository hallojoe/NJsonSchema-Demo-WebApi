namespace NJsonSchemaWebApi
{
    internal static class Constants
    {

        internal const string DefaultJsonInputValue = @"{ 
            'prop1': 'hello', 
            'prop2': true, 
            'prop3': 3, 
            'prop4': [
                'a', 'b', 'c'
            ], 
            'prop5': { 
                'prop51': 'hello', 
                'prop52': true, 
                'prop53': 3, 
                'prop54': [
                    1, 2, 3
                ] 
            } 
        }";

        internal const string DefaultJsonSchemaInputValue = @"{
            'type': 'object',
            'properties': {
                'postedProp1': {
                    'type': 'string'
                },
                'postedProp2': {
                    'type': 'boolean'
                },
                'postedProp3': {
                    'type': 'integer'
                },
                'postedProp4': {
                    'type': 'array',
                    'items': {
                        '$ref': '#/definitions/PostedProp4'
                    }
                },
                'postedProp5': {
                    '$ref': '#/definitions/PostedProp5'
                }
            },
            'definitions': {
                'PostedProp4': {
                    'type': 'string'
                },
                'PostedProp5': {
                    'type': 'object',
                    'properties': {
                        'postedProp1': {
                            'type': 'string'
                        },
                        'postedProp2': {
                            'type': 'boolean'
                        },
                        'postedProp3': {
                            'type': 'integer'
                        },
                        'postedProp4': {
                            'type': 'array',
                            'items': {
                                '$ref': '#/definitions/Anonymous3'
                            }
                        }
                    }
                },
                'Anonymous3': {
                    'type': 'string'
                }
            }
        }";

        internal const string DefaultCSharpInputValue = @"
using System;
using System.Collections.Generic;

public partial class Model
{   
    public virtual int Id { get; set; }
    public virtual string Name { get; set; }
    public virtual List<LinkViewModel> Links { get; set; }
    public virtual Dictionary<string, LinkViewModel> Dictionary { get; set; }
    public virtual string SmallText { get; set; }
    public virtual LinkViewModel Email { get; set; }
}

public partial class LinkViewModel
{   
    public virtual string Href { get; set; }
    public virtual string Label { get; set; }
    public virtual string Title { get; set; }
}    
            ";

        internal const string DefaultTypeScriptInputValue = @"

            export interface Model {
                postedProp1: string;
                postedProp2: boolean;
                postedProp3: number;
                postedProp4: string[];
                postedProp5: InnerType[];
                postedProp6: Array<boolean>;
                postedProp7: Map<number, InnerType>;
            }

            export type InnerType = {
                postedProp1: string,
                postedProp4: string[]
            }


        ";

        internal const string DefaultYamlInputValue = @"type: object
properties:
  postedProp1:
    type: string
  postedProp2:
    type: boolean
  postedProp3:
    type: integer
  postedProp4:
    type: array
    items:
      $ref: '#/definitions/PostedProp4'
  postedProp5:
    $ref: '#/definitions/PostedProp5'
definitions:
  PostedProp4:
    type: string
  PostedProp5:
    type: object
    properties:
      postedProp1:
        type: string
      postedProp2:
        type: boolean
      postedProp3:
        type: integer
      postedProp4:
        type: array
        items:
          $ref: '#/definitions/Anonymous3'
  Anonymous3:
    type: string";

    }

}
