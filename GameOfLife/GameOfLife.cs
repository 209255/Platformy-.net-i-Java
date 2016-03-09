using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameOfLife
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args == null) throw new ArgumentNullException("args");
            var newgame = new GameOfLife(10,10);
            newgame.DisplayWorld();
            while (true)
            {
                if (Console.ReadKey() == null) continue;
                newgame.NextAge();
                newgame.DisplayWorld();
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

        public bool IsDeadOrAlive(int row, int column)
        {
            if((row > 0 && column > 0) && (row < _vertical &&column < _horizontal ))
            return _world[row][column];
            else
            {
                throw new ArgumentException("Bledny zakres");
            }
        }
        public GameOfLife(string fileName)
        {
            _world = new List<List<bool>>();

            string directory = System.IO.Directory.GetCurrentDirectory();
            FileInfo f = new FileInfo(directory+ "\\" + fileName);
            string[] lines = System.IO.File.ReadAllLines(directory + "\\" + fileName);
            lines = lines.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            _vertical = lines.Length;
            _horizontal = ((int)f.Length-lines.Length)/lines.Length;
           
            for (var rows = 0; rows < _vertical; ++rows)
            {
                _world.Add(new List<bool>());
                for (var columns = 0; columns < _horizontal; ++columns)
                {
                    _world[rows].Add(string.Equals(lines[rows][columns], '1'));
                }
            }
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

