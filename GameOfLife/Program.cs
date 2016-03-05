using System;
using System.Collections.Generic;


namespace game_of_life
{
    class Program
    {
        static void Main(string[] args)
        {
            GameOfLife game = new GameOfLife(30, 30);
            game.DisplayWorld();
            while (true)
            {
                if (Console.ReadKey() != null)
                {
                    game.NextAge();
                    game.DisplayWorld();
                }
            }
        }
    }

    public class GameOfLife
    {
        List<List<bool>> world;
        readonly int horizontal;
        readonly int vertical;

        public GameOfLife(int x, int y)
        {
            world = new List<List<bool>>();
            if (x < 0 || y < 0)
                throw new ArgumentException("Wymiar świata nie moze być ujemny!");
            this.horizontal = x;
            this.vertical = y;
            PopulateWorld();
        }

        public void DisplayWorld()
        {
            Console.Clear();
            for (int rows = 0; rows < vertical; ++rows)
            {
                for (int columns = 0; columns < horizontal; ++columns)
                    Console.Write(world[rows][columns] ? "1 " : ". ");
                Console.WriteLine("");
            }
        }

        public void NextAge()
        {
            List<List<bool>> newWorld = new List<List<bool>>();

            for (int rows = 0; rows < vertical; ++rows)
            {
                int neighbours = 0;
                newWorld.Add(new List<bool>());
                for (int columns = 0; columns < horizontal; ++columns)
                {
                    neighbours = CountNeighbour(rows, columns);
                    if (world[rows][columns])
                    {
                        if (neighbours < 2 || neighbours > 3)
                            newWorld[rows].Add(false);
                        else if (neighbours == 2 || neighbours == 3)
                            newWorld[rows].Add(true);
                    }
                    else if (!world[rows][columns] && neighbours == 3)
                        newWorld[rows].Add(true);
                    else
                        newWorld[rows].Add(false);
                }
            }
            world = newWorld;
        }

        private int CountNeighbour(int i, int j)
        {
            int counter = 0;
            for (int rows = Math.Max(i - 1, 0); rows < Math.Min(i + 2, vertical); ++rows)
                for (int columns = Math.Max(j - 1, 0); columns < Math.Min(j + 2, horizontal); ++columns)
                    counter = world[rows][columns] ? ++counter : counter;
            counter = world[i][j] ? --counter : counter;
            return counter;
        }

        private void PopulateWorld()
        {
            Random rand = new Random();
            for (int rows = 0; rows < vertical; ++rows)
            {
                world.Add(new List<bool>());
                for (int columns = 0; columns < horizontal; ++columns)
                    world[rows].Add(rand.Next(100) > 50 ? true : false);
            }
        }
    }
}

