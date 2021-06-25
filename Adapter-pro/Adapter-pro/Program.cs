using Adapter_pro.Apapter;
using System;

namespace Adapter_pro
{
    class Program
    {
        static void Main(string[] args)
        {
            IStudent student = new StudentAdapter();
            string value = student.GetAllStudent();
            Console.WriteLine(value);
            Console.ReadLine();
        }
    }
}
