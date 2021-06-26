using System;

namespace AdapterDemo
{
    public class WizardAdapter : IFighter
    {
        
        private Wizard _wizard;
        
        public WizardAdapter(Wizard wizard)
        {
            this._wizard = wizard;
        }
        
        public void Attack()
        {
            Console.WriteLine(_wizard.Spell() + " at the enemy");
        }

        public void Defend()
        {
            Console.WriteLine(_wizard.Shield() + " to defend");
        }

        public void Escape()
        {
            Console.WriteLine(_wizard.Wings() + " to fly away");
        }
    }
}