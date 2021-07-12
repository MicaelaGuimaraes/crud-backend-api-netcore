using DataAccess.Mappings;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class Context : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
               @"Server=database-1.cslmyk6dvzby.us-east-1.rds.amazonaws.com;Initial Catalog=DataUsers;Persist Security Info=False;User ID=admin;Password=12345678;");
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMappings());

        }

        public DbSet<User> Users { get; set; }

    }
}
