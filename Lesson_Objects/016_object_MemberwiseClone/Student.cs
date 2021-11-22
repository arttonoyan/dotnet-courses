namespace _016_object_MemberwiseClone
{
    class Student
    {
        public string Email { get; init; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Fullname => $"{Surname} {Name}";

        public Student Clone() =>
            MemberwiseClone() as Student;
    }
}
