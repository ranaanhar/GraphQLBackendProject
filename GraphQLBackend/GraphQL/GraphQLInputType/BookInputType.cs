using System;
using GraphQL.Types;

namespace GraphQLBackend.GraphQL.GraphQLInputType;

public class BookInputType:InputObjectGraphType
{
    public BookInputType(){
        Name="bookInput";
        Field<StringGraphType>("id");
        Field<StringGraphType>("title");
        Field<StringGraphType>("isbn");
        Field<StringGraphType>("authorId");
    }
}
