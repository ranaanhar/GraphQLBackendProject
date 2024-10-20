using System;
using GraphQL;
using GraphQL.Types;
using GraphQLBackend.Data;
using GraphQLBackend.GraphQL.GraphQLInputType;
using GraphQLBackend.GraphQL.GraphQLType;
using GraphQLBackend.Model;

namespace GraphQLBackend.GraphQL.GraphQLQuery;

public class RootMutation:ObjectGraphType
{
    public RootMutation(ILogger<RootQuery>logger,IDatabaseService database){
        Field<BookType>("addBook").Argument<BookInputType>("book").ResolveAsync(async context=>{
            var inputBook=context.GetArgument<Book>("book");
            await database.addBook(inputBook);
            return inputBook;
        });


        Field<BookType>("deleteBook").Argument<BookInputType>("Book").ResolveAsync(async context=>{
            var inputBook=context.GetArgument<Book>("book");
            await database.deleteBook(inputBook);
            return inputBook;
            });


        Field<BookType>("updateBook").Argument<BookInputType>("Book").ResolveAsync( async context=>{
            var inputBook=context.GetArgument<Book>("book");
            await database.updateBook(inputBook);
            return inputBook;
        });

        Field<AuthorType>("addAuthor").Argument<AuthorInputType>("author").ResolveAsync(async context=>{
            var inputAuthor=context.GetArgument<Author>("author");
            await database.addAuthor(inputAuthor);
            return inputAuthor;
        });

        Field<AuthorType>("deleteAuthor").Argument<AuthorInputType>("author").ResolveAsync(async context=>{
            var inputAuthor=context.GetArgument<Author>("author");
            await database.deleteAuthor(inputAuthor);
            return inputAuthor;
        });

        Field<AuthorType>("updateAuthor").Argument<AuthorInputType>("author").ResolveAsync(async context=>{
            var inputAuthor=context.GetArgument<Author>("author");
            await database.updateAuthor(inputAuthor);
            return inputAuthor;
        });
    }
}
