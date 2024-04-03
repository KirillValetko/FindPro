using Microsoft.EntityFrameworkCore;
using FindPro.DAL.Models;

namespace FindPro.DAL.Infrastructure
{
    public class FindProContext : DbContext
    {
        public FindProContext(DbContextOptions<FindProContext> options)
        : base(options)
        {
        }
        
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillGroup> SkillGroups { get; set; }
        public DbSet<SkillLevel> SkillLevels { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
