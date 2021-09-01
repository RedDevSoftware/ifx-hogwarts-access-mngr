namespace Ifx.Services.hogwartsAccess.Application.Admissions.Commands.Create
{
    using System;
    using MediatR;
    using System.Threading.Tasks;
    using System.Threading;
    using Ifx.Services.hogwartsAccess.Application.Infrastructure.Abstract;
    using Ifx.Services.hogwartsAccess.Domain.Entities;
    using Ifx.Services.hogwartsAccess.Domain.Enums;
    using AutoMapper;

    public class CreateAdmissionCommand : IRequest
    {
        public string Identification { get; set; }
        public string Age { get; set; }
        public HogwartsHouses HouseRequest { get; set; }

        public class Handler : IRequestHandler<CreateAdmissionCommand, Unit>
        {
            private readonly IAdmissionDbContext context;
            private readonly IMapper mapper;

            public Handler(IAdmissionDbContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<Unit> Handle(CreateAdmissionCommand request, CancellationToken cancellationToken)
            {
                var entityModel = new AdmissionModel
                {
                    Id = new Guid(),
                };

                var entity = mapper.Map<Admission>(entityModel);

                context.Admissions.Add(entity);
                await context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
