namespace Ifx.Services.hogwartsAccess.Application.Admissions.Commands.Create
{
    using MediatR;
    using System.Threading.Tasks;
    using System.Threading;
    using Ifx.Services.hogwartsAccess.Application.Infrastructure.Abstract;
    using Ifx.Services.hogwartsAccess.Domain.Entities;
    using Ifx.Services.hogwartsAccess.Domain.Enums;
    using AutoMapper;
    using System.Xml.Linq;
    using System.Linq;
    using Ifx.Services.hogwartsAccess.Application.Exceptions;

    public class CreateAdmissionCommand : IRequest
    {
        public string Identification { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
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
                var addStudent = await AddStudentAsync(request, cancellationToken);

                if (!addStudent)
                {
                    throw new GeneralException("An error occurred while adding the prospective student.");
                }

                var hasUsers = context.Admissions.Any(u => u.Identification == request.Identification && u.Status == StatusAdmission.PENDING);

                if (hasUsers)
                {
                    throw new AlreadyException(nameof(Admissions), request.Identification);
                }

                var entityModel = new AdmissionModel
                {
                    Identification = request.Identification,
                    Name = request.Name,
                    LastName = request.LastName,
                    Age = request.Age,
                    HouseRequest = request.HouseRequest
                };

                var entity = mapper.Map<Admission>(entityModel);

                context.Admissions.Add(entity);
                await context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }

            private async Task<bool> AddStudentAsync(CreateAdmissionCommand request, CancellationToken cancellationToken)
            {
                var hasUsers = context.Students.Any(u => u.Identification == request.Identification);

                if (!hasUsers)
                {
                    context.Students.Add(new Student {
                        Identification = request.Identification,
                        Name = request.Name,
                        LastName = request.LastName
                    });
                }

                return true;
            }
        }
    }
}
