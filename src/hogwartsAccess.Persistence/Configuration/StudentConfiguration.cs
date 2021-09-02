

namespace Ifx.Services.hogwartsAccess.Persistence.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Ifx.Services.hogwartsAccess.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("TBL_STUDENT");
            builder.HasKey(e => e.Identification);

            builder.Property(e => e.Identification)
                .HasColumnName("id")
                .HasMaxLength(13)
                .IsRequired();

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(e => e.LastName)
                .HasColumnName("lastName")
                .IsRequired();

            builder.HasData(new[] {
                new Student
                {
                    Identification = "1121931225",
                    Name = "Pedro",
                    LastName = "Cardenas"
                }
            });
        }
    }
}
