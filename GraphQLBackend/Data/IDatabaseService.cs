using System;
using GraphQLBackend.Model;

namespace GraphQLBackend.Data;

public interface IDatabaseService
{
    public Task<Book> getBook(string id, CancellationToken cancellationToken = default);
    public Task addBook(Book book, CancellationToken cancellationToken = default);
    public Task deleteBook(Book book, CancellationToken cancellationToken = default);
    public Task updateBook(Book book, CancellationToken cancellationToken = default);
    public Task<List<Book>> searchBook(Book book, CancellationToken cancellationToken = default);
    public Task<List<Book>> getBooks(CancellationToken cancellationToken = default);


    public Task<Author> getAuthor(string id, CancellationToken cancellationToken = default);
    public Task addAuthor(Author author, CancellationToken cancellationToken = default);
    public Task deleteAuthor(Author author, CancellationToken cancellationToken = default);
    public Task updateAuthor(Author author, CancellationToken cancellationToken = default);
    public Task<List<Author>> searchAuthor(Author author, CancellationToken cancellationToken = default);
    public Task<List<Author>> getAuthors(CancellationToken cancellationToken = default);

}
