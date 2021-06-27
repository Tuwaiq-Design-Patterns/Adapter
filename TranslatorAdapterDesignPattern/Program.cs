using System;
using System.Collections.Generic;
using TranslatorAdapterDesignPattern;

namespace TranslatorAdapterDesignPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
           
            Compound unknown = new Compound();
            unknown.Display();
           
            Compound water = new Adapter("Water");
            water.Display();

        
        }
    }

    //Target class
    public class Compound
    {
      
        protected string formula;
        public virtual void Display()
        {
            Console.WriteLine("Compound: Unknown ");
        }
    }

    //Adapter class
    public class Adapter : Compound
    {
        private string chemical;

        private ChemicalDatabank bank;

        //Constructor
        public Adapter(string chemical)
        {
            this.chemical = chemical;
        }
        public override void Display()
        {
            //The Adaptee
            bank = new ChemicalDatabank();
            formula = bank.GetMolecularStructure(chemical);
            Console.WriteLine("\nCompound: {0} ", chemical);
            Console.WriteLine(" Formula: {0}", formula);
        }
    }

    //Adaptee class
    public class ChemicalDatabank
    {
        public string GetMolecularStructure(string compound)
        {
            switch (compound.ToLower())
            {
                case "water": return "H20";
                default: return "";
            }
        }

    }
}