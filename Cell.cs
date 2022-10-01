using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15Puzzle
{
    public class Cell
    {
        private int X { get; set; }
        private int Y { get; set; }
        public string Content { get; set; }
        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
