using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLBackend.Model;

public class Book
{
    [Key]
    public string? Id { get; set;}
    public string? Title { get; set; }
    public string? ISBN { get; set; }
    public string? AuthorId { get; set; }
    public virtual Author? Author { get; set; }
}
