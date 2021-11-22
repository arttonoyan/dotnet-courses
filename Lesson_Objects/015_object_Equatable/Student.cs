using System;

namespace _015_object_Equatable
{
    class Student : IEquatable<Student>
    {
        public string Email { get; init; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Fullname => $"{Surname} {Name}";

        public bool Equals(Student other)
        {
            if (other == null)
                return false;

            return Email == other.Email;
        }
    }
}
