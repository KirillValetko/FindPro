using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FindPro.DAL.Models;

namespace FindPro.DAL.Infrastructure.ModelConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.IsActive).IsRequired();
            builder.HasOne(e => e.Grader)
                .WithMany()
                .HasForeignKey(e => e.GraderId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);
        }
    }
}
