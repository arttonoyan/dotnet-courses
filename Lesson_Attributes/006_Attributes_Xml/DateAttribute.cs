using System;
namespace _006_Attributes_Xml
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    internal class DateAttribute : Attribute
    {
        public DateAttribute(string format)
        {
            Format = format;
        }

        public string Format { get; }
    }
}
