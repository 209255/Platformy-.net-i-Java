using System;

namespace GameOfLife
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                int vertical, horizontal;
                Console.WriteLine("Wprowadź szerokość świata");
                horizontal = int.Parse(Console.ReadLine());
                Console.WriteLine("Wprowadź długość świata");
                vertical = int.Parse(Console.ReadLine());
                GameOfLife newgame = new GameOfLife(horizontal, vertical);
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
                Console.WriteLine(e.Message);
                Console.WriteLine("Aplikacja zostanie zakończona");
                Console.Read();
            }
        }
    }
}
