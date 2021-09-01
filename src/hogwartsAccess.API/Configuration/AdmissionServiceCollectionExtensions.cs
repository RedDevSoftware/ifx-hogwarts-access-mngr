namespace Microsoft.Extensions.DependencyInjection
{
    using Ifx.Services.hogwartsAccess.Application.Infrastructure.Abstract;
    using Ifx.Services.hogwartsAccess.Application.Infrastructure.Mapping;
    using Ifx.Services.hogwartsAccess.Application.Admissions.Queries;
    using Ifx.Services.hogwartsAccess.Persistence;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    public static class AdmissionServiceCollectionExtensions
    {
        public static IServiceCollection AddAdmissionApplication(this IServiceCollection service)
        {
            var sp = service.BuildServiceProvider();
            var configuration = sp.GetService<IConfiguration>();

            service.AddDbContext<IAdmissionDbContext, AdmissionDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AdmissionDB")));

            service.AddMediatR(typeof(ListAdmissionsQuery.Handler));

            service.AddAutoMapper(typeof(AdmissionProfile));

            return service;
        }
    }
}
