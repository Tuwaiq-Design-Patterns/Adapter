using System;

namespace AdapteDesignPattren
{
    class Program
    {

        public static void Main()
        {
         

            // Adapted chemical compounds
            Compound water = new RichCompound("Water");
            water.Display();

            Compound benzene = new RichCompound("Benzene");
            benzene.Display();

            Compound ethanol = new RichCompound("Ethanol");
            ethanol.Display();

      
       }
    }

    class Compound
    {
        protected string _chemical;
  
        protected string _molecularFormula;

        // Constructor
        public Compound(string chemical)
        {
            this._chemical = chemical;
        }

        public virtual void Display()
        {
            Console.WriteLine("\nCompound: {0} ------ ", _chemical);
        }
    }

    /// <summary>
    /// The 'Adapter' class
    /// </summary>
    class RichCompound : Compound
    {
        private ChemicalDatabank _bank;

        // Constructor
        public RichCompound(string name)
          : base(name)
        {
        }

        public override void Display()
        {
            // The Adaptee
            _bank = new ChemicalDatabank();
            _molecularFormula = _bank.GetMolecularStructure(_chemical);

            base.Display();
            Console.WriteLine(" Formula: {0}", _molecularFormula);
 
        }
    }

    /// <summary>
    /// The 'Adaptee' class
    /// </summary>
    class ChemicalDatabank
    {

        public string GetMolecularStructure(string compound)
        {
            switch (compound.ToLower())
            {
                case "water": return "H20";
                case "benzene": return "C6H6";
                case "ethanol": return "C2H5OH";
                default: return "";
            }
        }


    }


}
