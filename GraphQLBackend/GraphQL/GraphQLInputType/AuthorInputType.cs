using System;
using GraphQL.Types;

namespace GraphQLBackend.GraphQL.GraphQLInputType;

public class AuthorInputType:InputObjectGraphType
{
    public AuthorInputType(){
        Name="authorInput";
        Field<StringGraphType>("id");
        Field<StringGraphType>("name");
        Field<StringGraphType>("bio");
    }
    
}
