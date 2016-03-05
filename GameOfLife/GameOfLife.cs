using System;
using System.Collections.Generic;

namespace GameOfLife
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var game = new GameOfLife(30, 30);
            game.DisplayWorld();
            while (true)
            {
                if (Console.ReadKey() == null) continue;
                game.NextAge();
                game.DisplayWorld();
            }
        }
    }

    public class GameOfLife
    {
        List<List<bool>> _world;
        readonly int _horizontal;
        readonly int _vertical;

        public GameOfLife(int x, int y)
        {
            _world = new List<List<bool>>();
            if (x < 0 || y < 0)
                throw new ArgumentException("Wymiar świata nie moze być ujemny!");
            _horizontal = x;
            _vertical = y;
            PopulateWorld();
        }

        public void DisplayWorld()
        {
            Console.Clear();
            for (var rows = 0; rows < _vertical; ++rows)
            {
                for (var columns = 0; columns < _horizontal; ++columns)
                    Console.Write(_world[rows][columns] ? "1 " : ". ");
                Console.WriteLine("");
            }
        }

        public void NextAge()
        {
            var newWorld = new List<List<bool>>();

            for (var rows = 0; rows < _vertical; ++rows)
            {
                newWorld.Add(new List<bool>());
                for (var columns = 0; columns < _horizontal; ++columns)
                {
                    var neighbours = CountNeighbour(rows, columns);
                    if (_world[rows][columns])
                    {
                        if (neighbours < 2 || neighbours > 3)
                            newWorld[rows].Add(false);
                        else if (neighbours == 2 || neighbours == 3)
                            newWorld[rows].Add(true);
                    }
                    else if (!_world[rows][columns] && neighbours == 3)
                        newWorld[rows].Add(true);
                    else
                        newWorld[rows].Add(false);
                }
            }
            _world = newWorld;
        }

        private int CountNeighbour(int i, int j)
        {
            var counter = 0;
            for (var rows = Math.Max(i - 1, 0); rows < Math.Min(i + 2, _vertical); ++rows)
                for (var columns = Math.Max(j - 1, 0); columns < Math.Min(j + 2, _horizontal); ++columns)
                    counter = _world[rows][columns] ? ++counter : counter;
            counter = _world[i][j] ? --counter : counter;
            return counter;
        }

        private void PopulateWorld()
        {
            var rand = new Random();
            for (var rows = 0; rows < _vertical; ++rows)
            {
                _world.Add(new List<bool>());
                for (var columns = 0; columns < _horizontal; ++columns)
                    _world[rows].Add(rand.Next(100) > 50);
            }
        }
    }
}

