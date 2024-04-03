using FindPro.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindPro.DAL.Infrastructure.ModelConfigurations
{
    public class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.HasKey(g => g.Id);
            builder.Property(g => g.GradeDate).IsRequired();
            builder.Property(g => g.Comment).IsRequired();
            builder.Property(g => g.IsActive).IsRequired();
            builder.HasOne(g => g.SkillLevel)
                .WithMany(sl => sl.Grades)
                .HasForeignKey(g => g.SkillLevelId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            builder.HasOne(g => g.EmployeeSkill)
                .WithMany(es => es.Grades)
                .HasForeignKey(g => g.EmployeeSkillId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
