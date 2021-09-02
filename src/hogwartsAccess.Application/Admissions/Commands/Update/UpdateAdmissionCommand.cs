namespace Ifx.Services.hogwartsAccess.Application.Admissions.Commands.Update
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Ifx.Services.hogwartsAccess.Application.Exceptions;
    using Ifx.Services.hogwartsAccess.Application.Infrastructure.Abstract;
    using Ifx.Services.hogwartsAccess.Domain.Entities;
    using Ifx.Services.hogwartsAccess.Domain.Enums;
    using MediatR;

    public class UpdateAdmissionCommand : IRequest
    {
        public Guid Id { get; set; }
        public StatusAdmission Status { get; set; }

        public class Handler : IRequestHandler<UpdateAdmissionCommand, Unit>
        {
            private readonly IAdmissionDbContext context;
            private readonly IMapper mapper;

            public Handler(IAdmissionDbContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<Unit> Handle(UpdateAdmissionCommand request, CancellationToken cancellationToken)
            {
                var hasAdmission = context.Admissions.Any(u => u.Id == request.Id);
                if (!hasAdmission)
                {
                    throw new NotFoundException(nameof(Admission), request.Id);
                }

                var entity = context.Admissions.Where(d => d.Id == request.Id).First();
                entity.Status = request.Status;

                context.Admissions.Update(entity);
                await context.SaveChangesAsync(cancellationToken);
                
                return Unit.Value;
            }
        }
    }
}
