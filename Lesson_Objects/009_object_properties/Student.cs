namespace _009_object_properties
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

        public int Age
        {
            get { return age; }
            set
            {
                if (14 >= value || value > 50)
                    age = 0;
                else
                    age = value;
            }
        }

        //public int get_Age()
        //{
        //    return age;
        //}

        //public void set_Age(int value)
        //{
        //    if (14 >= value || value > 50)
        //        age = 0;
        //    else
        //        age = value;
        //}
    }
}
