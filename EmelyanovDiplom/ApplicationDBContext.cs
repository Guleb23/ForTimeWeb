using EmelyanovApp.Models;
using EmelyanovDiplom.Models;
using Microsoft.EntityFrameworkCore;

namespace EmelyanovDiplom
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Provider> Provider { get; set; }
        public DbSet<Uslugi> Uslugi { get; set; }
    }
}
