using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infastracted.Data
{
    public class ProgramDbContext : DbContext
    {
        public ProgramDbContext(DbContextOptions<ProgramDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<EducationalProgram> EducationalPrograms { get; set; }

        public DbSet<EducationalModule> EducationalModules { get; set; }

        public DbSet<Institute> Institutes { get; set; }
        
        public DbSet<HeadUser> HeadUsers { get; set; }
        
        public DbSet<User> Users { get; set; }
        
    }
}