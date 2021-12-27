using System;

namespace _002_Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    class MyAttribute : Attribute
    {
        public MyAttribute(string date)
        {
            this.date = date;
        }

        private readonly string date;
        public string Date
        {
            get { return date; }
        }

        public int Number { get; set; }
    }
}
