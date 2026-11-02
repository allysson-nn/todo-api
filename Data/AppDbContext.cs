using Microsoft.EntityFrameworkCore;
using todo_api.Models;

namespace todo_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Isso diz ao EF Core para criar uma tabela chamada "Tasks" baseada na model TaskItem
        public DbSet<TaskItem> Tasks { get; set; } 
    }
}
