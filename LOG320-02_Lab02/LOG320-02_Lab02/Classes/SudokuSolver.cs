using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;

namespace LOG320_02_Lab02.Classes
{
    public class SudokuSolver
    {

        private const int TAILLE_JEU_9X9 = 81;
        private const int Test = 6;

        public Sudoku SolveTextFile(HttpPostedFile file)
        {
            // Read the text file
            StreamReader sr = new StreamReader(file.InputStream);
            bool wrongFile = false;
            int y = 0;
            int x = 0;
            int? currentValue = null;
            Sudoku sudoku = new Sudoku();
            StringBuilder line = new StringBuilder(sr.ReadLine());
            while (!sr.EndOfStream && !wrongFile)
            {
                while (x < line.Length)
                {
                    try
                    {
                        currentValue = int.Parse(line[x].ToString());
                        sudoku.Rows[y].Nodes[x] = new SudokuNode(currentValue, new Coordinate(x, y));
                        sudoku.Columns[x].Nodes[y] = new SudokuNode(currentValue, new Coordinate(x, y));
                        sudoku.Regions[(((x + 1) % 3) + 1) * (((y + 1) % 3) + 1) - 1].Nodes[0] = new SudokuNode(currentValue, new Coordinate(x, y));
                    }
                    catch
                    {
                        wrongFile = true;
                        break;
                    }
                    x++;
                }
                y++;
                line = new StringBuilder(sr.ReadLine());
            }
            sr.Close();

            if (wrongFile)
            {
                return null;
            }
            return sudoku;
        }
    }
}