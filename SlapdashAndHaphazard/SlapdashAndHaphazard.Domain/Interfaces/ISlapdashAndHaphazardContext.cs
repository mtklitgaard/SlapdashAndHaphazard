using System.Data.Entity;

namespace SlapdashAndHaphazard.Domain.Interfaces
{
    public interface ISlapdashAndHaphazardContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<Tag> Tags { get; set; }
    }
}