using EFTemplates.Logging.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace EFTemplates.Logging.Context
{
    class EFTemplatesLoggingContext: DbContext
    {

        private StreamWriter _writer = new StreamWriter("EFCoreLog.txt", append: true);

        public DbSet<Account> Accounts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=EFTemplatesLoggingExample")
                .LogTo(Console.WriteLine)
                //.LogTo(_writer.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Debug)
                //.LogTo(_writer.WriteLine, new[] { DbLoggerCategory.Database.Command.Name })
                //.LogTo(_writer.WriteLine)
                .EnableSensitiveDataLogging();
            
        }
    }
}
