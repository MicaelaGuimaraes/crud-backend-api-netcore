using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Mappings
{
    public class UserMappings : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey("Id");
            builder.Property(x => x.Name).HasColumnType("varchar(max)");
            builder.Property(x => x.Age).HasColumnType("int");
            builder.Property(x => x.Email).HasColumnType("varchar(max)");
            builder.Property(x => x.Address).HasColumnType("varchar(max)");
            builder.Property(x => x.CreateDate).HasColumnType("datetime");
        }
    }
}
