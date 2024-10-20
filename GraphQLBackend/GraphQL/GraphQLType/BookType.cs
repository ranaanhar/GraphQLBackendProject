using System;
using GraphQL.Types;
using GraphQLBackend.Model;

namespace GraphQLBackend.GraphQL.GraphQLType;

public class BookType:ObjectGraphType<Book>
{
    public BookType(){
        Field<StringGraphType>("id").Description("The Id of The Book");
        Field<StringGraphType>("title").Description("The Title of The Book");
        Field<StringGraphType>("isbn").Description("The ISBN of The Book");
        Field<StringGraphType>("authorId").Description("The Authors Id");
    }
}
