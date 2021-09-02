namespace Ifx.Services.hogwartsAccess.Application.Admissions.Commands.Delete
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Ifx.Services.hogwartsAccess.Application.Exceptions;
    using Ifx.Services.hogwartsAccess.Application.Infrastructure.Abstract;
    using Ifx.Services.hogwartsAccess.Domain.Entities;
    using MediatR;

    public class DeleteAdmissionCommand : IRequest
    {
        public Guid Id { get; set; }

        public class Handler : IRequestHandler<DeleteAdmissionCommand, Unit>
        {
            private readonly IAdmissionDbContext context;
            private readonly IMapper mapper;

            public Handler(IAdmissionDbContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<Unit> Handle(DeleteAdmissionCommand request, CancellationToken cancellationToken)
            {
                var hasAdmission = context.Admissions.Any(u => u.Id == request.Id);
                if (!hasAdmission)
                {
                    throw new NotFoundException(nameof(Admission), request.Id);
                }

                var entity = context.Admissions.Where(d => d.Id == request.Id).First();

                context.Admissions.Remove(entity);
                await context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
