using Microsoft.EntityFrameworkCore;
using Dotnet21.CorrectContext.Models;
using Microsoft.Extensions.Configuration;

namespace Dotnet21.CorrectContext
{
    public class CorrectContext : DbContext
    {
        private readonly IConfiguration _configuration;
        
        public CorrectContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString(nameof(CorrectContext)));
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(p => p.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<Profile>(p => p.Id);

            modelBuilder.Entity<Profile>()
                .HasOne(p => p.User)
                .WithOne(p => p.Profile)
                .HasForeignKey<User>(p => p.Id);

            base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
    }
}