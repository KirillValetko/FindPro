using Microsoft.EntityFrameworkCore;
using FindPro.DAL.Models;

namespace FindPro.DAL.Infrastructure
{
    public class FindProContext : DbContext
    {
        public FindProContext(DbContextOptions<FindProContext> options)
        : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }
        
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillGroup> SkillGroups { get; set; }
        public DbSet<SkillLevel> SkillLevels { get; set; }
        public DbSet<GradedSkill> GradedSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
