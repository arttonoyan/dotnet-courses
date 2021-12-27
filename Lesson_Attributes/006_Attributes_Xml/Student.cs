using System;

namespace _006_Attributes_Xml
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        [Date("dd/MM/yyyy")]
        public DateTime BirthDay { get; set; }

        [Ignore]
        public int Age => DateTime.Now.Year - BirthDay.Year;

        [Ignore]
        public string Fullname => $"{Name} {Surname}";
    }
}
