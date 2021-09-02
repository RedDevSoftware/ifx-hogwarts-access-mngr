namespace Ifx.Services.hogwartsAccess.Application.Admissions.Queries
{
    using System;
    using Ifx.Services.hogwartsAccess.Domain.Enums;

    public class AdmissionModel
    {
        public Guid Id { get; set; }
        public string Identification { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string HouseRequest { get; set; }
        public string Status { get; set; }
    }
}
