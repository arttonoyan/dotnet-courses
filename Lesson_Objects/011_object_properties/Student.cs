namespace _011_object_properties
{
    class Student
    {
        public Student(string email)
        {
            this.email = email;
        }

        public readonly string email;
        public string Surname { get; set; }
        public string Name { get; set; }
    }

}
