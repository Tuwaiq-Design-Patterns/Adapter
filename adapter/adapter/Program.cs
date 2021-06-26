using System;

namespace adapter
{
   //Target is to unlock the chest
    public interface ITarget
    {
        string OpenChest();
    }

    //service is earing the treasure within the chest
    class EarnTreasure
    {
        public string UnlockChest()
        {
            return "Unlocking Chest";
        }
    }

    // adapter is a special key that unlocks the chest
    class SpecialKey : ITarget
    {
        private readonly EarnTreasure _adaptee;

        public SpecialKey(EarnTreasure adaptee)
        {
            this._adaptee = adaptee;
        }

        public string OpenChest()
        {
            return $"Player can only '{this._adaptee.UnlockChest()}' with a special key";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            EarnTreasure adaptee = new EarnTreasure();
            ITarget target = new SpecialKey(adaptee);

            Console.WriteLine(target.OpenChest());
        }
    }
}
