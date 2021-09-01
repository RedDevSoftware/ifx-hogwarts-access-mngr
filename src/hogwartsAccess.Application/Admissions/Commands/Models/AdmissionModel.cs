namespace Ifx.Services.hogwartsAccess.Application.Admissions.Commands
{
    using System;
    using Ifx.Services.hogwartsAccess.Domain.Enums;

    public class AdmissionModel
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Identification { get; set; }
        public string Age { get; set; }
        public HogwartsHouses HouseRequest { get; set; }
        public StatusAdmission Status { get; set; }
    }
}
