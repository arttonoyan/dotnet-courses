namespace _007_object_readonly
{
    class Student
    {
        public Student(string email)
        {
            this.email = email;
        }

        public readonly string email;

        public string name;
        public string surname;
        public int age;
    }

}
