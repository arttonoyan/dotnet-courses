namespace _003_Reflection_Xml
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public string Fullname => $"{Name} {Surname}";
    }
}
