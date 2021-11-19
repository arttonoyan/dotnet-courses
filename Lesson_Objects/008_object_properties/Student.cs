namespace _008_object_properties
{
    class Student
    {
        public Student(string email)
        {
            this.email = email;
        }

        public string name;
        public string surname;
        public readonly string email;
        private int age;

        public void SetAge(int value)
        {
            if (14 >= value || value > 50)
                age = 0;
            else
                age = value;
        }

        public int GetAge()
        {
            return age;
        }
    }

}
