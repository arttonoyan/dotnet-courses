using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _003_Reflection_Xml
{
    public static class XmlExtensions
    {
        public static void WriteToXml_Old_2<T>(this IEnumerable<T> source, string filename)
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

            var properties = type
                .GetProperties()
                .Where(pi => pi.GetCustomAttribute<IgnoreAttribute>() == null);

            foreach (var item in source)
            {
                //Start Type
                xmlWriter.WriteStartElement(type.Name);

                foreach (var property in properties)
                {
                    xmlWriter.WriteStartElement(property.Name);
                    var value = property.GetValue(item);
                    xmlWriter.WriteValue(value);
                    xmlWriter.WriteEndElement();
                }

                //End Type
                xmlWriter.WriteEndElement();
            }

            //ListOfTypes
            xmlWriter.WriteEndElement();
        }

        public static void WriteToXml_Old(this IEnumerable<Student> source, string filename)
        {
            using var xmlWriter = new XmlTextWriter("students.xml", null)
            {
                Formatting = Formatting.Indented,
                IndentChar = '\t',
                Indentation = 1
            };

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("ListOfStudents");

            foreach (var item in source)
            {
                //Start Student
                xmlWriter.WriteStartElement(nameof(Student));

                xmlWriter.WriteStartElement(nameof(Student.Id));
                xmlWriter.WriteValue(item.Id);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement(nameof(Student.Name));
                xmlWriter.WriteString(item.Name);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement(nameof(Student.Surname));
                xmlWriter.WriteString(item.Surname);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement(nameof(Student.Age));
                xmlWriter.WriteValue(item.Age);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement(nameof(Student.Email));
                xmlWriter.WriteString(item.Email);
                xmlWriter.WriteEndElement();

                //End Student
                xmlWriter.WriteEndElement();
            }

            // ListOfStudents
            xmlWriter.WriteEndElement();
        }

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

                foreach (var member in type.GetProperties())
                {
                    var value = member.GetValue(instance);

                    xmlWriter.WriteStartElement(member.Name);
                    xmlWriter.WriteValue(value);
                    xmlWriter.WriteEndElement();
                }

                //End Type
                xmlWriter.WriteEndElement();
            }

            // ListOfStudents
            xmlWriter.WriteEndElement();
        }
    }
}
