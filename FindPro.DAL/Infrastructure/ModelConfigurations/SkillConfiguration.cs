using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FindPro.DAL.Models;

namespace FindPro.DAL.Infrastructure.ModelConfigurations
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.Property(s => s.SkillName).IsRequired();
            builder.Property(s => s.IsUsed).IsRequired();
            builder.Property(s => s.IsActive).IsRequired();
            builder.Property(s => s.GroupId).IsRequired();
        }
    }
}
