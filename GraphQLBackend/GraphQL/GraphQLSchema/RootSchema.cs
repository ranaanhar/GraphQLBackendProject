using System;
using GraphQL.Types;
using GraphQLBackend.GraphQL.GraphQLQuery;

namespace GraphQLBackend.GraphQL.GraphQLSchema;

public class RootSchema : Schema, ISchema
{
    public RootSchema(IServiceProvider services) : base(services)
    {
        Query=services.GetRequiredService<RootQuery>();
        Mutation=services.GetRequiredService<RootMutation>();
    }
}
