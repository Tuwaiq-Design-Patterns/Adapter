using System;
using System.Collections.Generic;
using System.Linq;

namespace Adapter
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }        

        public override string ToString()
        {
            return $"Id {Id}  FirstName: {FirstName}  LastName: {LastName}";
        }
    }

   
    public class RecordServer
    {
        private List<Student> _students;

        public RecordServer()
        {
            InitializeEmployees();
        }

        public List<Student> ReturnStudent()
        {
            return _students;
        }

        private void InitializeEmployees()
        {
            _students = new List<Student>
        {
            new Student { Id = 1, FirstName = "Amal" , LastName = "Fahad"},
            new Student { Id = 2, FirstName = "Leenah" , LastName = "Fahad"},            
        };
        }
    }


    public interface IStudentService
    {
        Student ReturnStudent(int studentId);
    }

   
    public class StudentService : IStudentService
    {
        RecordServer recordServer;

        public StudentService()
        {
            recordServer = new RecordServer();
        }

      
        public Student ReturnStudent(int employeeId)
        {
            var allEmployees = recordServer.ReturnStudent();
            return allEmployees.FirstOrDefault(e => e.Id == employeeId);
        }
   
    }

    class Program
    {
        static void Main(string[] args)
        {

            IStudentService service = new StudentService();

            var student = service.ReturnStudent(1);
            PrintStudentDetails(student);

            student = service.ReturnStudent(2);
            PrintStudentDetails(student);

            student = service.ReturnStudent(3);
            PrintStudentDetails(student);

            Console.Read();
        }

        static void PrintStudentDetails(Student student)
        {
            if (student != null)
                Console.WriteLine(student);
            else
                Console.WriteLine("Student not found");
        }
    }
}
