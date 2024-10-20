using System;
using System.ComponentModel.DataAnnotations;

namespace GraphQLBackend.Model;

public class Author
{
    [Key]
    public string? Id { get; set;}
    public string? Name { get; set;}
    public string? Bio { get; set; }
    public virtual ICollection<Book>? Books { get; set; }
}
