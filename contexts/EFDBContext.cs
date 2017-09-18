using System;
using Microsoft.EntityFrameworkCore;
using NancyService.models;

namespace NancyService.contexts
{
    public class EFDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO: look at a better lib to use
            string host = Environment.GetEnvironmentVariable("SQL_HOST");
            string user = Environment.GetEnvironmentVariable("SQL_USER");
            string password = Environment.GetEnvironmentVariable("SQL_PASSWORD");
            optionsBuilder.UseSqlServer(@"Server=" + host + ";Database=master;User Id="+ user +";Password=" + password);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employees");
        }
    }
}