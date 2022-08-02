namespace _016_object_MemberwiseClone
{
    class Student
    {
        public string Email { get; init; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Fullname => $"{Surname} {Name}";

        public University University { get; set; }

        public Student Clone()
        {
            var st = MemberwiseClone() as Student;
            st.University = University.Clone();
            return st;
        }
    }

    class University
    {
        public int Id { get; set; }

        public University Clone() =>
            MemberwiseClone() as University;
    }
}
