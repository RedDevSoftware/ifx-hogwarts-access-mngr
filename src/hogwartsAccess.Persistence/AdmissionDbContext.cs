namespace Ifx.Services.hogwartsAccess.Persistence
{
    using Ifx.Services.hogwartsAccess.Application.Infrastructure.Abstract;
    using Ifx.Services.hogwartsAccess.Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public class AdmissionDbContext : DbContext, IAdmissionDbContext
    {
        public AdmissionDbContext(DbContextOptions<AdmissionDbContext> options)
            : base (options)
        {
        }

        public DbSet<Admission> Admissions { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AdmissionDbContext).Assembly);
        }
    }
}
