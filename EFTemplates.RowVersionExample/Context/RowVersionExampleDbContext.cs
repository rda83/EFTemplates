using EFTemplates.RowVersionExample.Models;
using Microsoft.EntityFrameworkCore;

namespace EFTemplates.RowVersionExample.Context
{
    class RowVersionExampleDbContext : DbContext
    {
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Results> Results { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=EFTemplatesRowVersionExample");

        }
    }
}
