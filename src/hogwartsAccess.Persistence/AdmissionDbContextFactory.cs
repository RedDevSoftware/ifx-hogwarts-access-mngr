namespace Ifx.Services.hogwartsAccess.Persistence
{
    using Ifx.Services.hogwartsAccess.Persistence.Infrastructure;
    using Microsoft.EntityFrameworkCore;

    public class AdmissionDbContextFactory : DesignTimeDbContextFactoryBase<AdmissionDbContext>
    {
        protected override AdmissionDbContext CreateNewInstance(DbContextOptions<AdmissionDbContext> options)
        {
            return new AdmissionDbContext(options);
        }
    }
}
