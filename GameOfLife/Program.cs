using System;

namespace GameOfLife
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                GameOfLife newgame = new GameOfLife(-1, 10);
                newgame.DisplayWorld();
                while (true)
                {
                    if (Console.ReadKey() == null) continue;
                    newgame.NextAge();
                    newgame.DisplayWorld();
                }
            }
            catch (ArgumentException e)
            {
                Console.Write(e.Message);
            }
       }
    }
}
