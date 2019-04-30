using System;
using System.Linq;

namespace ZombieGame
{
    class Program
    {

        static void Main(string[] args)
        {
            ConsoleGame game = new ConsoleGame();
            int[] round = new int[10];

            for (int i = 0; i < round.Length; i++)
            {
                round[i] = game.Play(); // Play() method returns an integer which shows how many rounds it takes to turn all human to zombies
            }
            int avg = (int)round.Average(); 
            
            Console.WriteLine($"The average rounds to turn all houseowners to zombies is {avg}");

        }
    }
}
