using Domain.ToDos;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
