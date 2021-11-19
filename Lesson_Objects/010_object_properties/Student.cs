namespace _010_object_properties
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

        //public string FullName_mock
        //{
        //    get { return $"{surname} {name}"; }
        //}

        public string FullName => $"{surname} {name}";

        public int Test() => 10;
        //{
        //    return 10;
        //}

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
    }

}
