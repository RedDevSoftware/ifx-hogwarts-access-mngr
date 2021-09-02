namespace Ifx.Services.hogwartsAccess.Application.Tests.Admissions.Commands
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Ifx.Services.hogwartsAccess.Application.Admissions.Commands.Create;
    using Ifx.Services.hogwartsAccess.Application.Exceptions;
    using Ifx.Services.hogwartsAccess.Application.Tests.Infrastructure;
    using Ifx.Services.hogwartsAccess.Persistence;
    using Shouldly;
    using Xunit;

    [Collection("QueryCollection")]
    public class CreateHandlerTests
    {
        private readonly AdmissionDbContext context;
        private readonly IMapper mapper;

        public CreateHandlerTests(QueryTestFixture fixture)
        {
            context = fixture.Context;
            mapper = fixture.Mapper;
        }

        [Fact]
        public void ShouldThrowAlreadyException()
        {
            var handler = new CreateAdmissionCommand.Handler(context, mapper);

            Should.Throw<AlreadyException>(() => handler.Handle(
                    new CreateAdmissionCommand
                    {
                        Identification = "1121931225",
                        Age = "16",
                        Name = "ANDRES",
                        LastName = "CANO",
                        HouseRequest = Domain.Enums.HogwartsHouses.Hufflepuff
                    }, CancellationToken.None
                )
            );
        }

        [Fact]
        public void ShouldThrowInvalidOperationException()
        {
            var handler = new CreateAdmissionCommand.Handler(context, mapper);

            Should.Throw<InvalidOperationException>(() => handler.Handle(
                    new CreateAdmissionCommand { }, CancellationToken.None
                )
            );
        }

        [Fact]
        public void ShouldCreateSuccessTest()
        {
            var handler = new CreateAdmissionCommand.Handler(context, mapper);

            Should.NotThrow(() => handler.Handle(new CreateAdmissionCommand
            {
                Identification = "1121832485",
                Age = "12",
                Name = "CARLOS",
                LastName = "TELLEZ",
                HouseRequest = Domain.Enums.HogwartsHouses.Hufflepuff
            }, CancellationToken.None));
        }
    }
}