using System.Collections.Generic;

namespace _013_object_HashCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var st1 = new Student { name = "A1", email = "a1@gmail.com" };
            var st2 = new Student { name = "A1", email = "a1@gmail.com" };

            if(st1.Equals(st2))
            {

            }

            var set = new HashSet<Student>();
            set.Add(st1);
            set.Add(st2);
        }
    }

    class Student
    {
        public string name;
        public string email;

        public override int GetHashCode()
        {
            return email.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var st = obj as Student;
            if (st == null)
                return false;

            return email == st.email;
        }

        public override string ToString()
        {
            return email;
        }
    }
}
