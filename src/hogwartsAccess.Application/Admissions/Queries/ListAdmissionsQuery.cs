namespace Ifx.Services.hogwartsAccess.Application.Admissions.Queries
{
using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Ifx.Services.hogwartsAccess.Application.Infrastructure.Abstract;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class ListAdmissionsQuery : IRequest<IList<AdmissionModel>>
    {
        public class Handler : IRequestHandler<ListAdmissionsQuery, IList<AdmissionModel>>
        {
            private readonly IAdmissionDbContext context;
            private readonly IMapper mapper;

            public Handler(IAdmissionDbContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<IList<AdmissionModel>> Handle(ListAdmissionsQuery request, CancellationToken cancellationToken)
            {
                return await context.Admissions
                    .ProjectTo<AdmissionModel>(mapper.ConfigurationProvider)
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
            }
        }
    }
}
