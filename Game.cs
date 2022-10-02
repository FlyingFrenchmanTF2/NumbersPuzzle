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
                string selectedNumber = GetNumber();
                (int, int) numberCoordinates = LocateCell(selectedNumber);
                (int,int)[] ListOfPerpendiculars = FindPerpendiculars(numberCoordinates);

                foreach (var PerpendicularCell in ListOfPerpendiculars)
                {
                    (int prow, int pcolumn) = PerpendicularCell;
                    (int orow, int ocolumn) = numberCoordinates;
                    if ((prow >= 0 && prow <= 3) && (pcolumn >= 0 && pcolumn <= 3))
                    {
                        if (board.MyBoard[prow, pcolumn].Content == " ")
                        {
                            board.MyBoard[prow, pcolumn].Content = board.MyBoard[orow, ocolumn].Content;
                            board.MyBoard[orow, ocolumn].Content = " ";
                            break;
                        }
                    }
                }
                Console.Clear();

            }
            Console.WriteLine("You win");
;
        }
        public (int,int)[] FindPerpendiculars((int,int) originalCoords)
        {
            (int row, int column) = originalCoords;
            (int, int)[] ListOfPerpendicularCells = new (int,int)[4];
            (int, int) UpperCell = (row - 1, column);
            (int, int) LowerCell = (row + 1, column);
            (int, int) LeftCell = (row, column - 1);
            (int, int) RightCell = (row, column + 1);
            ListOfPerpendicularCells[0] = UpperCell;
            ListOfPerpendicularCells[1] = LowerCell;
            ListOfPerpendicularCells[2] = LeftCell;
            ListOfPerpendicularCells[3] = RightCell;
            return ListOfPerpendicularCells;

        }
        public string GetNumber()
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
        public (int,int) LocateCell(string input )
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
        public bool HasWon()
        {
            int counter = 1;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if ((counter == 16) && (board.MyBoard?[3, 3].Content) == " ")
                    {
                        return true;
                    }
                    if ((board.MyBoard?[i, j].Content) != Convert.ToString(counter))
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
