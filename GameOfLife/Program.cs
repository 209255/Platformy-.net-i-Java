using System;

namespace GameOfLife
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args == null) throw new ArgumentNullException("args");
            GameOfLife newgame = new GameOfLife(10, 10);
            newgame.DisplayWorld();
            while (true)
            {
                if (Console.ReadKey() == null) continue;
                newgame.NextAge();
                newgame.DisplayWorld();
            }
        }
    }
}
