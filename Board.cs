using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _15Puzzle
{
    public class Board
    {
        public Cell[,]? MyBoard { get; set; }

        Random random = new Random();
        List<string> listOfNumbers = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", " " };

        public void Generate()
        {
            MyBoard = new Cell[4, 4];
            //Generates a 4x4 table
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    MyBoard[i, j] = new Cell(i, j);
                    int randomIndex = random.Next(listOfNumbers.Count);
                    MyBoard[i, j].Content = listOfNumbers[randomIndex];
                    listOfNumbers.RemoveAt(randomIndex);
                }
            }
        }

        public void GenerateObjective()
        {
            Console.WriteLine("This is how it should look like");
            Console.WriteLine("+------+------+------+------+");
            Console.WriteLine("|   1  |   2  |   3  |   4  |");
            Console.WriteLine("+------+------+------+------+");
            Console.WriteLine("|   5  |   6  |   7  |   8  |");
            Console.WriteLine("+------+------+------+------+");
            Console.WriteLine("|   9  |  10  |  11  |  12  |");
            Console.WriteLine("+------+------+------+------+");
            Console.WriteLine("|  13  |  14  |  15  |      |");
            Console.WriteLine("+------+------+------+------+");

        }
        public void Draw()
        {
            Console.WriteLine("+---------------------------+");
            Console.WriteLine($"|{MyBoard[0, 0].Content,4}  |{MyBoard[0, 1].Content,4}  |{MyBoard[0, 2].Content,4}  |{MyBoard[0, 3].Content,4}  |");
            Console.WriteLine("+---------------------------+");                                                 
            Console.WriteLine($"|{MyBoard[1, 0].Content,4}  |{MyBoard[1, 1].Content,4}  |{MyBoard[1, 2].Content,4}  |{MyBoard[1, 3].Content,4}  |");
            Console.WriteLine("+---------------------------+");                                                 
            Console.WriteLine($"|{MyBoard[2, 0].Content,4}  |{MyBoard[2, 1].Content,4}  |{MyBoard[2, 2].Content,4}  |{MyBoard[2, 3].Content,4}  |");
            Console.WriteLine("+---------------------------+");                                                 
            Console.WriteLine($"|{MyBoard[3, 0].Content,4}  |{MyBoard[3, 1].Content,4}  |{MyBoard[3, 2].Content,4}  |{MyBoard[3, 3].Content,4}  |");
            Console.WriteLine("+---------------------------+");
        }
    } 
}
