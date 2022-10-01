using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15Puzzle
{
    internal class Game

    {
        Board board = new Board();
        public void Start()
        {
            board.GenerateObjective();
            board.Generate();

            while (HasWon() == false)
            {
                board.Draw();
                MoveNumber();

                Console.Clear();
            }
;
        }

        public string MoveNumber()
        {
            Console.WriteLine("What cell do you wish to move (1 - 15)?");
            string? input;
            while (true)
            {
                input = Console.ReadLine();
                if (Convert.ToInt32(input) < 1 || Convert.ToInt32(input) > 15)
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                return input;
            }

        }
        public (int,int) LocateCell(Board board, string input )
        {
            (int, int) coordinates;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (board.MyBoard[i, j].Content == input)
                    {
                        coordinates = (i, j);
                        return coordinates;
                    }
                }

            }
            return (0, 0);
        }
        public void IsLegalMove()
        {

        }
        public bool HasWon()
        {
            int counter = 1;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Convert.ToInt32(board.MyBoard?[i, j].Content) != counter)
                    {
                        return false;
                    }
                    counter++;
                }
            }
            return true;
        }
    }
}
