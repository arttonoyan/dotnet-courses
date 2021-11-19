namespace _005_object
{
    class Student
    {
        public Student() { }

        public Student(string name)
        {
            if (name.Length > 0 && char.IsLetter(name[0]))
                this.name = name;
        }

        public Student(string name, string surname)
            : this(name)
        {
            //this.name = name;
            this.surname = surname;
        }

        public Student(string name, string surname, int age)
            : this(name, surname)
        {
            //this.name = name;
            //this.surname = surname;
            this.age = age;
        }

        public string name;
        public string surname;
        public int age;
    }

}
