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

        public static class Wizard
        {
            public static string CastDestructionSpell()
            {
                return "Casted a very huge fireball";
            }

            public static string Shield()
            {
                return "Conjured a reliable and sturdy shield";
            }

            public static string Portal()
            {
                return "Opened a portal to another dimension";
            }
        }

        public class WizardAdapter : IFighter
        {
            public void attack()
            {
                Console.WriteLine(Wizard.CastDestructionSpell() + " at the enemy");
            }

            public void defend()
            {
                Console.WriteLine(Wizard.Shield() + " to defend");
            }

            public void escape()
            {
                Console.WriteLine(Wizard.Portal() + " and jumped into it");
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
