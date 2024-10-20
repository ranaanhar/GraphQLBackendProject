using System;

namespace GraphQLBackend.Model;

public class GraphQLRequest
{
    public string? query { get; set; }
    public string? operationName { get;}
    public string? variables { get; set; }
}
