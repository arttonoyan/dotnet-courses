using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;

namespace _006_Attributes_Xml
{
    public static class XmlExtensions
    {
        public static void WriteToXml<T>(this IEnumerable<T> source, string filename)
        {
            using var xmlWriter = new XmlTextWriter(filename, null)
            {
                Formatting = Formatting.Indented,
                IndentChar = '\t',
                Indentation = 1
            };

            var type = typeof(T);

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement($"ListOf{type.Name}s");

            foreach (var instance in source)
            {
                //Start Type
                xmlWriter.WriteStartElement(type.Name);

                foreach (var member in type.GetProperties().Where(NotIgnored))
                {
                    xmlWriter.WriteStartElement(member.Name);

                    var value = member.GetValue(instance);
                    var date = member.GetCustomAttribute<DateAttribute>();
                    if (date == null)
                        xmlWriter.WriteValue(value);
                    else
                    {
                        var dateValue = (DateTime)value;
                        xmlWriter.WriteValue(dateValue.ToString(date.Format));
                    }

                    xmlWriter.WriteEndElement();
                }

                //End Type
                xmlWriter.WriteEndElement();
            }

            // ListOfStudents
            xmlWriter.WriteEndElement();
        }

        public static bool NotIgnored(this PropertyInfo pi) =>
            pi.GetCustomAttribute<IgnoreAttribute>() == null;
    }
}
