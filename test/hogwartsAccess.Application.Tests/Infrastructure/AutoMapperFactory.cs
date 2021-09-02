namespace Ifx.Services.hogwartsAccess.Application.Tests.Infrastructure
{
    using AutoMapper;
    using Ifx.Services.hogwartsAccess.Application.Infrastructure.Mapping;

    public class AutoMapperFactory
    {
        public static IMapper Create()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AdmissionProfile());
            });

            return mappingConfig.CreateMapper();
        }
    }
}
