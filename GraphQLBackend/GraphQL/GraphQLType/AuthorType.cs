using System;
using GraphQL.Types;
using GraphQLBackend.Model;

namespace GraphQLBackend.GraphQL.GraphQLType;

public class AuthorType:ObjectGraphType<Author>
{
    public AuthorType(){
        Field<StringGraphType>("id").Description("The Id of The Author");
        Field<StringGraphType>("name").Description("The Name of The Author");
        Field<StringGraphType>("bio").Description("The Bio of The Author");
    }
}
