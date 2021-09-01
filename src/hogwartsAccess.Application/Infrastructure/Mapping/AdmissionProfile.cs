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
                .ForMember(dest => dest.Status, source => source.MapFrom(source => Enum.GetName(typeof(StatusAdmission), source.Status)))
                .ForMember(dest => dest.HouseRequest, source => source.MapFrom(source => Enum.GetName(typeof(HogwartsHouses), source.HouseRequest)));

            CreateMap<Admissions.Commands.AdmissionModel, Admission>()
                .ForMember(dest => dest.Status, source => source.MapFrom(source => StatusAdmission.PENDING));
        }
    }
}