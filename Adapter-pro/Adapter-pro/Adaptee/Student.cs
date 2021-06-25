using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Adapter_pro
{

    [Serializable]
    public class Student
    {
        Student() { }
        public Student(string firstName, string lastName, int id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ID = id;

        }
        [XmlAttribute]
        public int ID { get; set; }
        [XmlAttribute]
        public string FirstName { get; set; }

        [XmlAttribute]
        public string LastName { get; set; }


    }




    public class StudentRecord
    {
        public List<Student> students;
        public StudentRecord()
        {
            students = new List<Student>();
            this.students.Add(new Student("Osama", "Mohamed", 1));
            this.students.Add(new Student("Rahaf", "Ahmad", 1));
            this.students.Add(new Student("sara", "Fahad", 1));
        }
        public virtual string GetAllStudent()
        {
            var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(students.GetType());
            var settings = new XmlWriterSettings(); 
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            var stream = new StringWriter();
            var writer = XmlWriter.Create(stream, settings);
                serializer.Serialize(writer, students, emptyNamepsaces);
                return stream.ToString();
            

        }
    }

}