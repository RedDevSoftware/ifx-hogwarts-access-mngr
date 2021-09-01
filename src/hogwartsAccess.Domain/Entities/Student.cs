namespace Ifx.Services.hogwartsAccess.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Student
    {
        public Student()
        {
            Admissions = new HashSet<Admission>();
        }

        public string Identification { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public ICollection<Admission> Admissions { get; set; }
    }
}
