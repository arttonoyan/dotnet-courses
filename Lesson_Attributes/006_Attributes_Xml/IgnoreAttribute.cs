using System;

namespace _006_Attributes_Xml
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    internal class IgnoreAttribute : Attribute
    {
    }
}
