using FindPro.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindPro.DAL.Infrastructure.ModelConfigurations
{
    public class GradedSkillConfiguration : IEntityTypeConfiguration<GradedSkill>
    {
        public void Configure(EntityTypeBuilder<GradedSkill> builder)
        {
            builder.HasKey(gs => gs.Id);
            builder.Property(gs => gs.Comment).IsRequired();
            builder.Property(gs => gs.IsActive).IsRequired();
            builder.HasOne(gs => gs.Employee)
                .WithMany(e => e.GradedSkills)
                .HasForeignKey(gs => gs.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            builder.HasOne(gs => gs.Skill)
                .WithMany(s => s.GradedSkills)
                .HasForeignKey(gs => gs.SkillId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            builder.HasOne(gs => gs.SkillLevel)
                .WithMany(sl => sl.GradedSkills)
                .HasForeignKey(gs => gs.SkillLevelId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
