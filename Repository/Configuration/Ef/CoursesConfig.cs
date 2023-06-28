
using dotnet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet.Repository.Configuration.Ef
{
    public class CoursesConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("tb_courses");

            builder.HasKey(x => new { x.Id });

            builder.Property(x => x.Id)
                .HasColumnName("CourseId")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnName("NOME")
                .IsRequired();

            builder.Property(x => x.Category)
                .HasColumnName("CATEGORIA")
                .IsRequired();
        }
    }
}