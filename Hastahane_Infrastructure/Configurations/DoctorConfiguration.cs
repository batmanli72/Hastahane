using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Hastahane_Domain.Entities;

namespace Hastahane_Infrastructure.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.FullName).IsRequired().HasMaxLength(100);
            builder.Property(d => d.Specialty).IsRequired().HasMaxLength(100);

            builder.HasOne(d => d.Department)
                   .WithMany(dep => dep.Doctors)
                   .HasForeignKey(d => d.DepartmentId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}