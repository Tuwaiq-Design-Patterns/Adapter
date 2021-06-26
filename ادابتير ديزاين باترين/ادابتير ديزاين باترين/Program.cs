using System;

namespace ادابتير_ديزاين_باترين
{
    class Program
    {
        static void Main(string[] args)
        {
            واجهة_العدو عدو = new عدوأدابتر();
            Console.WriteLine(عدو.هجوم());
        }
    }
}