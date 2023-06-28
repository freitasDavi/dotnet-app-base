using dotnet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet.Repository.Configuration.Ef
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
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

            builder.Property(x => x.DataNascimento)
                .HasColumnName("DATA_NASC");
        }
    }
}