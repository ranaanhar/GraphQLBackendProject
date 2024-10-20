using System;
using System.Collections.Immutable;
using GraphQLBackend.Model;
using Microsoft.EntityFrameworkCore;

namespace GraphQLBackend.Data;

public class DatabaseService(ILogger<DatabaseService> logger, IServiceScopeFactory serviceScopeFactory) : IDatabaseService
{


    //Get Book by Id
    public async Task<Book> getBook(string id, CancellationToken cancellationToken = default)
    {
        var book = new Book();
        using (var scope = serviceScopeFactory.CreateAsyncScope())
        {
            var db = scope.ServiceProvider.GetService<Database>();
            book = await db!.Books.Where(x => x.Id == id).FirstAsync();
        }
        return book;
    }
    //ADD Book
    public async Task addBook(Book book, CancellationToken cancellationToken = default)
    {
        using (var scope = serviceScopeFactory.CreateScope())
        {
            var db = scope.ServiceProvider.GetService<Database>();
            book.Id = Guid.NewGuid().ToString();
            var result = await db!.Books.AddAsync(book);
        }
    }


    //DELETE Book
    public Task deleteBook(Book book, CancellationToken cancellationToken = default)
    {
        using (var scope = serviceScopeFactory.CreateScope())
        {
            var db = scope.ServiceProvider.GetService<Database>();
            var result = db!.Books.Remove(book);
        }
        return Task.CompletedTask;
    }

    //UPDATE Book
    public Task updateBook(Book book, CancellationToken cancellationToken = default)
    {
        using (var scope = serviceScopeFactory.CreateScope())
        {
            var db = scope.ServiceProvider.GetService<Database>();
            var result = db!.Books.Update(book);
        }
        return Task.CompletedTask;
    }



    //Search Book
    public async Task<List<Book>> searchBook(Book book, CancellationToken cancellationToken = default)
    {
        var result = new List<Book>();
        using (var scope = serviceScopeFactory.CreateScope())
        {
            var db = scope.ServiceProvider.GetService<Database>();
            result = await db!.Books.Where(_book => (_book.Title ?? "").Contains((book.Title ?? "").ToLower())).Select(_book => _book).ToListAsync();//and other filter
        }
        return result;
    }

    //Get All Books
    public async Task<List<Book>> getBooks(CancellationToken cancellationToken)
    {
        var books = new List<Book>();
        using (var scope = serviceScopeFactory.CreateAsyncScope())
        {
            var db = scope.ServiceProvider.GetService<Database>();
            books = await db!.Books.Select(i => i).ToListAsync();
        }
        logger.LogInformation("service return {0} of books", books.Count());
        return books;
    }

    //Get Author by Id
    public async Task<Author> getAuthor(string id, CancellationToken cancellationToken = default)
    {
        var author = new Author();
        using (var scope = serviceScopeFactory.CreateScope())
        {
            var db = scope.ServiceProvider.GetService<Database>();
            author = await db!.Authors.Where(x => x.Id == id).FirstAsync();
        }
        return author;
    }


    //Add Author
    public async Task addAuthor(Author author, CancellationToken cancellationToken = default)
    {
        using (var scope = serviceScopeFactory.CreateScope())
        {
            var db = scope.ServiceProvider.GetService<Database>();
            author.Id = Guid.NewGuid().ToString();
            await db!.Authors.AddAsync(author, cancellationToken);
        }
    }


    //Delete Author
    public Task deleteAuthor(Author author, CancellationToken cancellationToken = default)
    {
        using (var scope = serviceScopeFactory.CreateScope())
        {
            var db = scope.ServiceProvider.GetService<Database>();
            db!.Authors.Remove(author);
        }
        return Task.CompletedTask;
    }


    //Update Author
    public Task updateAuthor(Author author, CancellationToken cancellationToken = default)
    {
        using (var scope = serviceScopeFactory.CreateScope())
        {
            var db = scope.ServiceProvider.GetService<Database>();
            db!.Authors.Update(author);
        }
        return Task.CompletedTask;
    }


    //Search Author
    public async Task<List<Author>> searchAuthor(Author author, CancellationToken cancellationToken = default)
    {
        var result = new List<Author>();
        using (var scope = serviceScopeFactory.CreateScope())
        {
            var db = scope.ServiceProvider.GetService<Database>();
            result = await db!.Authors.Where(_author => (_author.Name ?? "").ToLower().Contains((author.Name ?? "").ToLower())).ToListAsync();//and other filter
        }
        return result;
    }


    //Get All Authors
    public async Task<List<Author>> getAuthors(CancellationToken cancellationToken = default)
    {
        var authors = new List<Author>();
        using (var scope = serviceScopeFactory.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<Database>();
            authors = await db!.Authors.Select(i => i).ToListAsync();
        }
        return authors;
    }
}
