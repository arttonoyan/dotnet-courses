namespace _006_object
{
    class Program
    {
        static void Main(string[] args)
        {
            //Student st = new Student(
            //    name: "A1", 
            //    surname: "A1yan", 
            //    age: 18);

            Student st = new()
            {
                name = "A1",
                surname = "A1yan",
                email = "a1@gmail.com",
                age = 18
            };

        }
    }
}
