using System;
using System.Collections.Generic;

namespace Adapter
{
    public class ReportingTool
    {
        private readonly ITarget _employeeSource;

        public ReportingTool(ITarget employeeSource)
        {
            _employeeSource = employeeSource;
        }

        public void ShowEmployeeList()
        {
            var employee = _employeeSource.GetEmployeeList();

            Console.WriteLine("%%%%% Headline %%%%%");
            Console.WriteLine("---------------------------------------");

            foreach (var item in employee) Console.Write(item);

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("%%%%% Footer %%%%%");
        }
    }

    public interface ITarget
    {
        IEnumerable<string> GetEmployeeList();
    }

    public class SAPSystem
    {
        public string[][] GetEmployees()
        {
            var employees = new string[4][];

            employees[0] = new[] { "ID", "Full Name", "Position" };
            employees[1] = new[] { "1", "Raneen Alzafarni", "Developer" };
            employees[2] = new[] { "2", "Reema Alyousef", "CEO" };
            employees[3] = new[] { "3", "Batool Alghamdi", "Janitor" };

            return employees;
        }
    }

    public class EmployeeAdapter : SAPSystem, ITarget
    {
        public IEnumerable<string> GetEmployeeList()
        {
            var employeeList = new List<string>();

            // get data from the SAP
            var employees = GetEmployees();

            // convert string into list
            foreach (var employee in employees)
            {
                employeeList.Add(employee[0]);
                employeeList.Add(AddSpaces(employee[0].Length, 5));
                employeeList.Add("| ");
                employeeList.Add(employee[1]);
                employeeList.Add(AddSpaces(employee[1].Length, 10));
                employeeList.Add("| ");
                employeeList.Add(employee[2]);
                employeeList.Add(AddSpaces(employee[2].Length, 20));
                employeeList.Add("\n");
            }

            // return list for third party tool
            return employeeList;
        }

        private string AddSpaces(int charsInColumn, int maxLength)
        {
            var result = "";

            for (var i = charsInColumn; i < maxLength; i++) result += " ";

            return result;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            ITarget target = new EmployeeAdapter();

            var client = new ReportingTool(target);

            client.ShowEmployeeList();

        }
    }
}
