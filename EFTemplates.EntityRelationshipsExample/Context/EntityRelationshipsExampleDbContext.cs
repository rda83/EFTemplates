using EFTemplates.EntityRelationshipsExample.Models;
using Microsoft.EntityFrameworkCore;

namespace EFTemplates.EntityRelationshipsExample.Context
{
    class EntityRelationshipsExampleDbContext : DbContext
    {
        public DbSet<AccountOwner> AccountOwners { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<BankCellsStorage> BankCellsStorages { get; set; }
        public DbSet<BankDepositBox> BankDepositBoxes { get; set; }
        public DbSet<ServiceEngineer> ServiceEngineers { get; set; }
        public DbSet<ATMMachine> ATMMachines { get; set; }
        public DbSet<CreditProductsGroup> CreditProductsGroups { get; set; }
        public DbSet<CreditProduct> CreditProducts { get; set; }
        public DbSet<PaymentOrdersRegister> PaymentOrdersRegisters { get; set; }
        public DbSet<PaymentOrder> PaymentOrders { get; set; }
        public DbSet<SecurityOfficer> SecurityOfficers { get; set; }
        public DbSet<SecurityIncident> SecurityIncidents { get; set; }
        public DbSet<SecurityKey> SecurityKeys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=EFTemplatesEntityRelationshipsExample");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Произвольное имя поля для хранения внешнего ключа
            modelBuilder.Entity<PaymentOrdersRegister>()
                .HasMany(s => s.PaymentOrders)
                .WithOne(q => q.PaymentOrdersRegister)
                .HasForeignKey(q => q.RegisterCode);

            // Связь многие ко многим (дополнительные данные)
            modelBuilder.Entity<AccountOwner>()
             .HasMany(s => s.SecurityIncidents)
             .WithMany(b => b.AccountOwners)
             .UsingEntity<AccountOwnerSecurityIncident>
              (bs => bs.HasOne<SecurityIncident>().WithMany(),
               bs => bs.HasOne<AccountOwner>().WithMany())
             .Property(bs => bs.DateOfIncident)
             .HasDefaultValueSql("getdate()");
        }
    }
}
