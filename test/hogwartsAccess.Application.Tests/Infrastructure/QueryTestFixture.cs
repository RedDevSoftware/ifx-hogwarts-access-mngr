namespace Ifx.Services.hogwartsAccess.Application.Tests.Infrastructure
{
    using System;
    using AutoMapper;
    using Ifx.Services.hogwartsAccess.Persistence;
    using Xunit;

    public class QueryTestFixture : IDisposable
    {
        public AdmissionDbContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public QueryTestFixture()
        {
            Context = AdmissionDbContextFactory.Create();
            Mapper = AutoMapperFactory.Create();
        }

        public void Dispose()
        {
            AdmissionDbContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
