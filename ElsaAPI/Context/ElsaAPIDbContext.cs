using ElsaAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ElsaAPI.Context
{
    public class ElsaAPIDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public ElsaAPIDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DB"));
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<User>();

            entity.ToTable("User", "public");

            entity.HasKey(p => new { p.Id });

            entity.Property(p => p.Id).UseIdentityColumn();
        }
    }
}
