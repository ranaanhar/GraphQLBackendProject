using System;
using GraphQLBackend.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GraphQLBackend.Data;

public class Database : DbContext
{
    public Database(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var author=new Author{
            Id=Guid.NewGuid().ToString(),
            Name="Alex Banks",
            Bio="Alex Banks is a software engineer, instructor, and coFounder of Moon Highway, a curriculum development company in Northern California"
        }; 
        modelBuilder.Entity<Author>().HasData(author);


        var book=new Book(){
            Id=Guid.NewGuid().ToString(),
            Title="Learning GraphQL",
            AuthorId=author.Id,
            ISBN=Guid.NewGuid().ToString(),
        };
        modelBuilder.Entity<Book>().HasData(book);
    }

    public virtual DbSet<Book> Books { get;set; }
    public virtual DbSet<Author> Authors { get;set; }
}
