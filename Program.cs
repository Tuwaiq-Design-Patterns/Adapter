using System;
using System.Collections.Generic;

namespace Adapter
{
    class Program
    {
        public class Employee
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public decimal Salary { get; set; }
            public Employee(int id, string name, decimal salary)
            {
                ID = id;
                Name = name;
                Salary = salary;
            }
        }

        public class ThirdPartyBillingSystem
        {
            public void ProcessSalary(List<Employee> listEmployee)
            {
                foreach (Employee employee in listEmployee)
                {
                    Console.WriteLine(employee.Salary + " SR. Salary Credited to " + employee.Name + " Account");
                }
            }
        }
        public interface ITarget
        {
            void ProcessCompanySalary(string[,] employeesArray);
        }

        public class EmployeeAdapter : ITarget
        {
            ThirdPartyBillingSystem thirdPartyBillingSystem = new ThirdPartyBillingSystem();

            public void ProcessCompanySalary(string[,] employeesArray)
            {
                string Id = null;
                string Name = null;
                string Salary = null;
                List<Employee> listEmployee = new List<Employee>();
                for (int i = 0; i < employeesArray.GetLength(0); i++)
                {
                    for (int j = 0; j < employeesArray.GetLength(1); j++)
                    {
                        if (j == 0)
                        {
                            Id = employeesArray[i, j];
                        }
                        else if (j == 1)
                        {
                            Name = employeesArray[i, j];
                        }
                        else
                        {
                            Salary = employeesArray[i, j];
                        }
                    }
                    listEmployee.Add(new Employee(Convert.ToInt32(Id), Name, Convert.ToDecimal(Salary)));
                }
                thirdPartyBillingSystem.ProcessSalary(listEmployee);
            }
        }
        static void Main(string[] args)
        {
            string[,] employeesArray = new string[10, 3]
             {
                {"1","Afra","10000"},
                {"2","Nora","10000"},
                {"3","Yara","15000"},
                {"4","Maram","14000"},
                {"5","Taif","12000"},
                {"6","Duaa","11000"},
                {"7","Sara","21000"},
                {"8","Manar","30000"},
                {"9","Fatima","14000"},
                {"10","Lara","20000"}
             };

            ITarget target = new EmployeeAdapter();
            target.ProcessCompanySalary(employeesArray);
        }
    }
    }
