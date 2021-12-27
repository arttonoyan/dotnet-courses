using System;

namespace _003_Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true)]
    public class MyAttribute : Attribute
    {
        public MyAttribute(string text, string data)
        {
            Text = text;
            Data = data;
        }

        public string Text { get; }

        public string Data { get; }

        public void Method()
        {
            Console.WriteLine("Attribute Method");
        }
    }
}
