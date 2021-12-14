using System;
using System.Collections.Generic;
using System.Linq;

namespace _008_Generics_Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var persons = CreatePersons(10);
            //var employees = CreateEmployees(20);

            ICopyable<Person> p = new Employee { Id = 10, Salary = 20 };
            var p2 = p.Copy();

            var persons = CreateArray<Person>(10);

            var rnd = new Random();
            var persons1 = CreateArray(10, () => rnd.Next());
            var employees = CreateArray<Employee>(20);

            Person[] ppp = CreateArray<Employee>(20);

            IMyList<Employee> myList = new MyList<Employee>();
            myList.PrintText = em => $"$ {em.Salary}";
            //myList.Add(new Customer());
            myList.Print();


            Person[] arr = CreateArray<Employee>(20);
            Customer[] aa = new Customer[20];
            arr.CopyTo(aa, 20);
            
            IReadOnlyList<Person> list = CreateList(20, () => new Employee());
            var aa1 = list[2];
        }

        public interface IMyList<T>
        {
            Func<T, string> PrintText { get; set; }
            void Add(T item);
            void Print();
        }

        public class MyList<T> : IMyList<T>
        {
            private readonly List<T> items = new List<T>();
            public Func<T, string> PrintText { get; set; }

            public void Add(T item)
            {
                items.Add(item);
            }

            public void Print()
            {
                foreach (var item in items)
                {
                    var text = PrintText.Invoke(item);
                    Console.WriteLine(text);
                }
            }
        }


        static TElement[] CreateArray<TElement>(int count, Func<TElement> func)
        {
            var elements = new TElement[count];
            for (int i = 0; i < count; i++)
                elements[i] = func.Invoke();
            return elements;
        }

        static List<TElement> CreateList<TElement>(int count, Func<TElement> func)
        {
            var elements = new List<TElement>(count);
            for (int i = 0; i < count; i++)
            {
                var element = func.Invoke();
                elements.Add(element);
            }
            return elements;
        }

        static TElement[] CreateArray<TElement>(int count)
            where TElement : class, new()
        {
            var elements = new TElement[count];
            for (int i = 0; i < count; i++)
                elements[i] = new TElement();
            return elements;
        }

        //static Person[] CreatePersons(int count)
        //{
        //    var persons = new Person[count];
        //    for (int i = 0; i < count; i++)
        //        persons[i] = new Person();
        //    return persons;
        //}

        //static Employee[] CreateEmployees(int count)
        //{
        //    var employees = new Employee[count];
        //    for (int i = 0; i < count; i++)
        //        employees[i] = new Employee();
        //    return employees;
        //}

        //static Customer[] CreateCustomers(int count)
        //{
        //    var customers = new Customer[count];
        //    for (int i = 0; i < count; i++)
        //        customers[i] = new Customer();
        //    return customers;
        //}
    }

    public class Person : ICopyable<Person>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public virtual Person Copy()
        {
            return MemberwiseClone() as Person;
        }
    }

    public class Employee : Person, ICopyable<Employee>
    {
        public int Salary { get; set; }

        public override Employee Copy()
        {
            var emp = base.Copy() as Employee;
            emp.Salary = Salary;
            return emp;
        }
    }

    public class Customer : Person
    {

    }
}
