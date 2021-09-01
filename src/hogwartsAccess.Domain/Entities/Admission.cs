namespace Ifx.Services.hogwartsAccess.Domain.Entities
{
    using System;
    using Ifx.Services.hogwartsAccess.Domain.Enums;

    public class Admission
    {
        public Guid Id { get; set; }
        public string Identification { get; set; }
        public string Age { get; set; }
        public HogwartsHouses HouseRequest { get; set; }
        public StatusAdmission Status { get; set; }

        public Student Students { get; set; }
    }
}
