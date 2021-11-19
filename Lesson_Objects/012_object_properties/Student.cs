namespace _012_object_properties
{
    class Student
    {
        public Student(string email)
        {
            Email = email;
        }

        public string Email { get; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Fullname => $"{Surname} {Name}";

        //public void SetEmail(string email)
        //{
        //    Email = email;
        //}
    }
}
