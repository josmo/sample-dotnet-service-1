﻿using System;
using Microsoft.EntityFrameworkCore;
using NancyService.models;

namespace NancyService.contexts
{
    public class EFDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Analyst> Analysts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO: look at a better lib to use
            var envHost = Environment.GetEnvironmentVariable("SQL_HOST");
            var envUser = Environment.GetEnvironmentVariable("SQL_USER");
            var envPassword = Environment.GetEnvironmentVariable("SQL_PASSWORD");

            var host = envHost ?? "localhost";
            var user = envUser ?? "sa";
            var password = envPassword ?? "yourStrong(!)Password";
           
            optionsBuilder.UseSqlServer(@"Server=" + host + ";Database=master;User Id="+ user +";Password=" + password);
        }

    }
}