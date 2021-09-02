namespace Ifx.Services.hogwartsAccess.Application.Tests.Infrastructure
{
    using Ifx.Services.hogwartsAccess.Persistence;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class AdmissionDbContextFactory
    {
        public static AdmissionDbContext Create()
        {
            var options = new DbContextOptionsBuilder<AdmissionDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new AdmissionDbContext(options);

            context.Database.EnsureCreated();

            context.SaveChanges();

            return context;
        }

        public static void Destroy(AdmissionDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
