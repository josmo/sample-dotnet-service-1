using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Nancy;

namespace NancyService
{
    public class DBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
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
    public class EmployeeEndpoints : NancyModule
    {
        public EmployeeEndpoints()
        {
            Get("/employees", args =>
            {
                using (var db = new DBContext())
                {
                    var employes = db.Employees.ToList();
                    return Response.AsJson(employes);
                }
            });
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public int id { get; set; }
        public int Age { get; set; }
        public string Status { get; set; }
    }

}

