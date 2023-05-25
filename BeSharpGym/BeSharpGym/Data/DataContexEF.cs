using BeSharpGym.Models;
using Microsoft.EntityFrameworkCore;

namespace BeSharpGym.Data
{
     public class DataContextEF : DbContext
    {
        private readonly IConfiguration _config;

        public DataContextEF(IConfiguration config)
        {
            _config = config;
        }

        public virtual DbSet<Member> Members {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            optionsBuilder
                .UseSqlServer(_config.GetConnectionString("DefaultConnection"),
                    optionsBuilder => optionsBuilder.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("BeSharpGymDataBase");

            modelBuilder.Entity<Member>()
            .ToTable("dbo.Members", "BeSharpGymDataBase")
            .HasKey(m => m.MemberId);
        }
        
    }
    }
   
