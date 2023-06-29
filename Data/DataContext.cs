using dotnet.Models;
using dotnet.Repository.Configuration.Ef;
using Microsoft.EntityFrameworkCore;

namespace dotnet.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new CoursesConfig());
            modelBuilder.ApplyConfiguration(new UsersConfig());
        }
    }
}