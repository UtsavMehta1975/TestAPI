// AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using ToDoApi.Models;

namespace ToDoApi
{
    // This class manages the connection to the database and the mapping of models to database tables.
    public class AppDbContext : DbContext
    {
        // required modifier ensures that this property must be initialized
        public required DbSet<ToDoItem> ToDoItems { get; set; }

        // Constructor accepting DbContextOptions to configure the context.
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
