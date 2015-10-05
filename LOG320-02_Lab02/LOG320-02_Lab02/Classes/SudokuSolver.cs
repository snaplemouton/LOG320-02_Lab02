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
        public Sudoku SolveTextFile(HttpPostedFile file)
        {
            // Read the text file
            StreamReader sr = new StreamReader(file.InputStream);
            bool wrongFile = false;
            int y = 0;
            int x = 0;
            int region;
            int nodeInRegion;
            int currentValue = 0;
            Sudoku sudoku = new Sudoku();
            StringBuilder line;
            while (!sr.EndOfStream && !wrongFile)
            {
                line = new StringBuilder(sr.ReadLine());
                while (x < line.Length)
                {
                    try
                    {
                        region = (int)Math.Floor(((decimal)x) / 3) + ((int)Math.Floor(((decimal)y) / 3) * 3);
                        nodeInRegion = x - ((region % 3) * 3) + ((y % 3) * 3);
                        currentValue = int.Parse(line[x].ToString());
                        sudoku.Rows[y].Nodes[x] = new SudokuNode(currentValue, new Coordinate(x, y), currentValue > 0);
                        sudoku.Columns[x].Nodes[y] = new SudokuNode(currentValue, new Coordinate(x, y), currentValue > 0);
                        sudoku.Regions[region].Nodes[nodeInRegion] = new SudokuNode(currentValue, new Coordinate(x, y), currentValue > 0);
                    }
                    catch
                    {
                        wrongFile = true;
                        break;
                    }
                    x++;
                }
                x = 0;
                y++;
            }
            sr.Close();

            if (wrongFile)
            {
                return null;
            }
            return SolveSudoku(sudoku);
        }

        public Sudoku SolveSudoku(Sudoku sudoku)
        {
            int y = 0;
            int x = 0;
            int num = 1;
            bool movingForward = true;
            while (y < sudoku.Rows.Length)
            {
                while (x < sudoku.Rows[y].Nodes.Length)
                {
                    if (!sudoku.Rows[y].Nodes[x].IsInitial)
                    {
                        movingForward = false;
                        while (num < 10)
                        {
                            sudoku.Rows[y].Nodes[x].Value = num;
                            sudoku.Columns[x].Nodes[y].Value = num;
                            //sudoku.Regions[0].Nodes[0].Value = num;
                            if (!SearchNodeList(sudoku.Rows[y], sudoku.Rows[y].Nodes[x]) &&
                                !SearchNodeList(sudoku.Columns[x], sudoku.Rows[y].Nodes[x]))
                            {
                                movingForward = true;
                                break;
                            }
                            num++;
                        }
                    }
                    if (movingForward)
                    {
                        x++;
                        num = 1;
                    }
                    else
                    {
                        if (x > 0)
                            x--;
                        else
                        {
                            if (y != 0)
                            {
                                y--;
                                x = 8;
                            }
                            else movingForward = true;
                        }
                        num = sudoku.Rows[y].Nodes[x].Value + 1;
                    }
                }
                y++;
                x = 0;
            }
            return sudoku;
        }

        public bool SearchNodeList(SudokuNodeArray array, SudokuNode node)
        {
            foreach (SudokuNode n in array.Nodes)
            {
                if (!n.Coordinate.Compare(node.Coordinate) && n.Value == node.Value) return true;
            }
            return false;
        }
    }
}