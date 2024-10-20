using System;
using GraphQL;
using GraphQL.Types;
using GraphQLBackend.Data;
using GraphQLBackend.GraphQL.GraphQLInputType;
using GraphQLBackend.GraphQL.GraphQLType;
using GraphQLBackend.Model;

namespace GraphQLBackend.GraphQL.GraphQLQuery;

public class RootQuery:ObjectGraphType
{
    public RootQuery(ILogger<RootQuery>logger,IDatabaseService database){

        

        Field<BookType>("getBook").Argument<BookInputType>("book").ResolveAsync(async context=>{
            var bookInput=context.GetArgument<Book>("book");
            var book =await database.getBook(bookInput.Id!);
            return book;
        });

        Field<ListGraphType<BookType>>("getAllBooks").ResolveAsync(async context=>{
            var books = await database.getBooks();
            return books;
        });

        Field<ListGraphType<BookType>>("searchBook").Argument<BookInputType>("book").ResolveAsync(async context=>{
            var book = context.GetArgument<Book>("book");
            var result=await database.searchBook(book);
            return result;
        });



        Field<AuthorType>("getAuthor").Argument<AuthorInputType>("author").ResolveAsync(async context=>{
            var authorInput=context.GetArgument<Author>("author");
            var author = await database.getAuthor(authorInput.Id!);
            return author;
        });

        Field<ListGraphType<AuthorType>>("getAllAuthors").ResolveAsync(async context=>{
            var authors=await database.getAuthors();
            return authors;
        });

        Field<ListGraphType<AuthorType>>("searchAuthor").Argument<AuthorInputType>("author").ResolveAsync(async context=>{
            var author = context.GetArgument<Author>("author");
            var result=await database.searchAuthor(author);
            return result;
        });
        
    }
}
