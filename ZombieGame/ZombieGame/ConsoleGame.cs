using System;
using System.Threading;

namespace ZombieGame
{
    class ConsoleGame
    {
        House[,] village;
        Random random = new Random();
        public int round;
        
        public int Play()
        {
            CreateVillage();
            Zombie.ZombieCount = 1;
            Person.PersonCount = 100;
            round = 0;

            // Runs until all the houseonwers have turned into zombies
            while (Zombie.ZombieCount < village.GetLength(0)*village.GetLength(1) +1)
            {
                round++;
                Console.Clear();
                DisplayVillage();
                Thread.Sleep(1000);
                CreateZombie();
            }

            return round;
        }

        private void DisplayVillage()
        {

            for (int i = 0; i < village.GetLength(0); i++)
            {
                for (int j = 0; j < village.GetLength(1); j++)
                {
                    if (village[i,j].Zombie is null)
                    {
                        Console.Write(" P ");
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else 
                    {
                        Console.Write(" Z ");
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                }
                Console.WriteLine();
            }
        }

        private void CreateZombie()
        {
            int currentZombie = Zombie.ZombieCount;

            // Randomise zombies
            for (int i = 0; i < currentZombie; i++)
            {
                int x = random.Next(0, 10);
                int y = random.Next(0, 10);

                if (village[x, y].Zombie is null)
                {
                    Zombie.ZombieCount++;
                    village[x, y].Zombie = new Zombie();
                    village[x, y].Person = null;
                    Person.PersonCount -= 1;
                }
            }
        }
       
        private void CreateVillage()
        {
            // Create 100 houses for the village
            village = new House[10, 10];

            // Print the houses
            for (int i = 0; i < village.GetLength(0); i++)
            {
                for (int j = 0; j < village.GetLength(1); j++)
                {
                    village[i, j] = new House();
                    // Create a houseowner for every house
                    village[i, j].Person = new Person();
                   
                }
            }
        }
    }
}