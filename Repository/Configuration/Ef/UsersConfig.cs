using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet.Repository.Configuration.Ef
{
    public class UsersConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("tb_users");

            builder.HasKey(x => new { x.Id });

            builder.Property(x => x.Id)
                .HasColumnName("USER_ID")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Nome)
                .HasColumnName("NOME")
                .IsRequired();

            builder.Property(x => x.Password)
                .HasColumnName("PASSWORD")
                .IsRequired();

            builder.Property(x => x.Role)
                .HasColumnName("ROLE")
                .IsRequired();
        }
    }
}