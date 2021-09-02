namespace Ifx.Services.hogwartsAccess.Persistence.Configuration
{
    using System;
    using Ifx.Services.hogwartsAccess.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AdmissionConfiguration : IEntityTypeConfiguration<Admission>
    {
        public void Configure(EntityTypeBuilder<Admission> builder)
        {
            builder.ToTable("TBL_ADMISSION");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.HasOne(d => d.Students)
                .WithMany(p => p.Admissions)
                .HasForeignKey(d => d.Identification)
                .HasConstraintName("FK_STUDENT_ADMISSION");

            builder.Property(e => e.Identification)
                .HasColumnName("identification")
                .HasMaxLength(13)
                .IsRequired();

            builder.Property(e => e.Age)
                .HasColumnName("age")
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(e => e.HouseRequest)
                .HasColumnName("houseRequest")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Status)
                .HasColumnName("status")
                .HasMaxLength(50)
                .IsRequired();

            builder.HasData(new[] {
                new Admission
                {
                    Id = Guid.Parse("b47e669d-b685-499a-a6b8-5bf0f694bdaa"),
                    Identification = "1121931225",
                    Age = "16",
                    Status = Domain.Enums.StatusAdmission.PENDING,
                    HouseRequest = Domain.Enums.HogwartsHouses.Slytherin
                }
            });
        }
    }
}
