using GraphQL;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using GraphQLBackend.Data;
using GraphQLBackend.GraphQL.GraphQLInputType;
using GraphQLBackend.GraphQL.GraphQLQuery;
using GraphQLBackend.GraphQL.GraphQLSchema;
using GraphQLBackend.GraphQL.GraphQLType;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Add Logging Console
builder.Logging.AddConsole();


//Services
var services = builder.Services;
services.AddSwaggerGen();


//Add Database to Service
services.AddDbContext<Database>(conf =>
{
    var connectionString = builder.Configuration.GetConnectionString("Default");
    conf.UseNpgsql(connectionString);
});


//GraphQL Stuff
services.AddSingleton<IDocumentExecuter,DocumentExecuter>();
services.AddSingleton<IGraphQLTextSerializer,GraphQLSerializer>();
services.AddSingleton<BookType>();
services.AddSingleton<BookInputType>();
services.AddSingleton<AuthorInputType>();
services.AddSingleton<AuthorType>();
services.AddSingleton<RootQuery>();
services.AddSingleton<RootMutation>();
services.AddSingleton<ISchema,RootSchema>();

services.AddSingleton<IDatabaseService,DatabaseService>();

//Add GraphQL to Service
services.AddGraphQL(conf=>{});

//Add Controller to Service
services.AddControllers();

var app = builder.Build();

//Use Swagger
if (builder.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Use Controllers
app.MapControllers();
app.Run();
