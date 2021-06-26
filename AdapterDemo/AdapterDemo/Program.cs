using System;

namespace AdapterDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Wizard wizard = new Wizard();
            IFighter fighter = new WizardAdapter(wizard);

            fighter.Attack();

            fighter.Defend();

            fighter.Escape();
        }
    }
}