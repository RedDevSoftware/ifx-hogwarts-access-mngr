namespace Ifx.Services.hogwartsAccess.Application.Tests.Admissions.Commands
{

    using System;
    using System.Threading;
    using AutoMapper;
    using Ifx.Services.hogwartsAccess.Application.Admissions.Commands.Update;
    using Ifx.Services.hogwartsAccess.Application.Exceptions;
    using Ifx.Services.hogwartsAccess.Application.Tests.Infrastructure;
    using Ifx.Services.hogwartsAccess.Persistence;
    using Shouldly;
    using Xunit;

    [Collection("QueryCollection")]
    public class UpdateHandlerTests
    {
        private readonly AdmissionDbContext context;
        private readonly IMapper mapper;

        public UpdateHandlerTests(QueryTestFixture fixture)
        {
            context = fixture.Context;
            mapper = fixture.Mapper;
        }

        [Fact]
        public void ShouldThrowNotFoundException()
        {
            var handler = new UpdateAdmissionCommand.Handler(context, mapper);

            Should.Throw<NotFoundException>(() => handler.Handle(
                    new UpdateAdmissionCommand
                    {
                        Id = Guid.NewGuid(),
                        Status = Domain.Enums.StatusAdmission.INPROGRESS
                    }, CancellationToken.None
                )
            );
        }

        [Fact]
        public void ShouldThrowInvalidOperationException()
        {
            var handler = new UpdateAdmissionCommand.Handler(context, mapper);

            Should.Throw<InvalidOperationException>(() => handler.Handle(
                    new UpdateAdmissionCommand { }, CancellationToken.None
                )
            );
        }

        [Fact]
        public void ShouldUpdateSuccessTest()
        {
            var handler = new UpdateAdmissionCommand.Handler(context, mapper);

            Should.NotThrow(() => handler.Handle(new UpdateAdmissionCommand
            {
                Id = Guid.Parse("b47e669d-b685-499a-a6b8-5bf0f694bdaa"),
                Status = Domain.Enums.StatusAdmission.INPROGRESS
            }, CancellationToken.None));
        }
    }
}
