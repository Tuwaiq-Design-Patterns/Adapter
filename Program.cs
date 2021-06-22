using System;

namespace Adapter
{
    class Program
    {

        public interface IDuel
        {
            public void myTurn();
            public void useSpell();
            public void useTrap();
            public void placeMonster();
            public void attackMonster();
        }

        public static class YugiohCardGame
        {
            public static string DrawACard()
            {
                return "Draw!!!";
            }

            public static string PlaySpell()
            {
                return "I use a spell card";
            }

            public static string PlayTrap()
            {
                return "I set a card";
            }
            public static string PlayMonster()
            {
                return "I play a moster";
            }
            public static string AttackUrMonster(){
                return "I Attack You're defense monster";
            }
        }

        public class MyTurn : IDuel
        {
            public void myTurn()
            {
                Console.WriteLine(YugiohCardGame.DrawACard() + " Sorry Kaiba You gona lose");
            }

            public void useSpell()
            {
                Console.WriteLine(YugiohCardGame.PlaySpell() + ", I Activate Pot of Greed to Draw 2 card from my deck");
            }

            public void useTrap()
            {
                Console.WriteLine(YugiohCardGame.PlayTrap() + ", I End my turn");
            }
            public void placeMonster(){
                Console.WriteLine(YugiohCardGame.PlayMonster()+" In attack postion");
            }
            public void attackMonster(){
                Console.WriteLine(YugiohCardGame.AttackUrMonster()+", Since my monster got a higher attack than you're defense it gonna destroy. I goto Stand by phase");
            }
        }



        static void Main(string[] args)
        {
            Console.WriteLine("It's my turn now");
            IDuel duel = new MyTurn();
            duel.myTurn();
            duel.useSpell();
            duel.placeMonster();
            duel.attackMonster();
            duel.useTrap();

            
            
        }
    }
}
