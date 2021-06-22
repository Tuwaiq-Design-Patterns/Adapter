using System;

namespace Adapter
{
    class Program
    {

        public interface IFighter
        {
            public void attack();
            public void defend();
            public void escape();
        }

        public class Wizard
        {
            public string CastDestructionSpell()
            {
                return "Casted a very huge fireball";
            }

            public string Shield()
            {
                return "Conjured a reliable and sturdy shield";
            }

            public string Portal()
            {
                return "Opened a portal to another dimension";
            }
        }

        public class WizardAdapter : IFighter
        {
            private readonly Wizard _wizard;

            public WizardAdapter()
            {
                _wizard = new Wizard();
            }
            public void attack()
            {
                Console.WriteLine(_wizard.CastDestructionSpell() + " at the enemy");
            }

            public void defend()
            {
                Console.WriteLine(_wizard.Shield() + " to defend");
            }

            public void escape()
            {
                Console.WriteLine(_wizard.Portal() + " and jumped into it");
            }
        }



        static void Main(string[] args)
        {
            IFighter fighter = new WizardAdapter();

            fighter.attack();

            fighter.defend();

            fighter.escape();
            
        }
    }
}
