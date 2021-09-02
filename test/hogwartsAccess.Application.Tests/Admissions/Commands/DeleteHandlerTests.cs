namespace Ifx.Services.hogwartsAccess.Application.Tests.Admissions.Commands
{

    using System;
    using System.Threading;
    using AutoMapper;
    using Ifx.Services.hogwartsAccess.Application.Admissions.Commands.Delete;
    using Ifx.Services.hogwartsAccess.Application.Exceptions;
    using Ifx.Services.hogwartsAccess.Application.Tests.Infrastructure;
    using Ifx.Services.hogwartsAccess.Persistence;
    using Shouldly;
    using Xunit;

    [Collection("QueryCollection")]
    public class DeleteHandlerTests
    {
        private readonly AdmissionDbContext context;
        private readonly IMapper mapper;

        public DeleteHandlerTests(QueryTestFixture fixture)
        {
            context = fixture.Context;
            mapper = fixture.Mapper;
        }

        [Fact]
        public void ShouldThrowNotFoundException()
        {
            var handler = new DeleteAdmissionCommand.Handler(context, mapper);

            Should.Throw<NotFoundException>(() => handler.Handle(
                    new DeleteAdmissionCommand
                    {
                        Id = Guid.NewGuid()
                    }, CancellationToken.None
                )
            );
        }

        [Fact]
        public void ShouldThrowInvalidOperationException()
        {
            var handler = new DeleteAdmissionCommand.Handler(context, mapper);

            Should.Throw<InvalidOperationException>(() => handler.Handle(
                    new DeleteAdmissionCommand { }, CancellationToken.None
                )
            );
        }

        [Fact]
        public void ShouldDeleteSuccessTest()
        {
            var handler = new DeleteAdmissionCommand.Handler(context, mapper);

            Should.NotThrow(() => handler.Handle(new DeleteAdmissionCommand
            {
                Id = Guid.Parse("b47e669d-b685-499a-a6b8-5bf0f694bdaa")
            }, CancellationToken.None));
        }
    }
}
