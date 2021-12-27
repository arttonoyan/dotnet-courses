using System;

namespace _001_Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    class MyAttribute : Attribute
    {
        public MyAttribute(string date)
        {
            this.date = date;
        }

        public MyAttribute(string date, int number)
            : this(date)
        {
            Number = number;
        }

        private readonly string date;
        public string Date
        {
            get { return date; }
        }

        public int Number { get; set; }
    }
}
