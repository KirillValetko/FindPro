using FindPro.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindPro.DAL.Infrastructure.ModelConfigurations
{
    public class EmployeeSkillConfiguration : IEntityTypeConfiguration<EmployeeSkill>
    {
        public void Configure(EntityTypeBuilder<EmployeeSkill> builder)
        {
            builder.HasKey(gs => gs.Id);
            builder.Property(gs => gs.IsActive).IsRequired();
            builder.HasOne(gs => gs.Employee)
                .WithMany(e => e.EmployeeSkills)
                .HasForeignKey(gs => gs.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
            builder.HasOne(gs => gs.Skill)
                .WithMany(s => s.EmployeeSkills)
                .HasForeignKey(gs => gs.SkillId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
