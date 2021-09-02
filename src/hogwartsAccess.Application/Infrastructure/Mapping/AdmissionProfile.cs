namespace Ifx.Services.hogwartsAccess.Application.Infrastructure.Mapping
{
    using System;
    using AutoMapper;
    using Ifx.Services.hogwartsAccess.Domain.Entities;
    using Ifx.Services.hogwartsAccess.Domain.Enums;

    public class AdmissionProfile : Profile
    {
        public AdmissionProfile()
        {
            CreateMap<Admission, Admissions.Queries.AdmissionModel>()
                .ForMember(dest => dest.Name, source => source.MapFrom(source => source.Students.Name))
                .ForMember(dest => dest.LastName, source => source.MapFrom(source => source.Students.LastName));

            CreateMap<Admissions.Commands.AdmissionModel, Admission>()
                .ForMember(dest => dest.Status, source => source.MapFrom(source => StatusAdmission.PENDING))
                .ForMember(dest => dest.Id, source => source.MapFrom(source => new Guid()));
        }
    }
}