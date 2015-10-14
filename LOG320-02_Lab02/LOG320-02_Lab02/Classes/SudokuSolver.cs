using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using System.Diagnostics;

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
                        sudoku.Rows[y].Nodes[x] = new SudokuNode(currentValue, new Coordinate(x, y), currentValue > 0, region, nodeInRegion);
                        sudoku.Columns[x].Nodes[y] = new SudokuNode(currentValue, new Coordinate(x, y), currentValue > 0, region, nodeInRegion);
                        sudoku.Regions[region].Nodes[nodeInRegion] = new SudokuNode(currentValue, new Coordinate(x, y), currentValue > 0, region, nodeInRegion);
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

        public Sudoku OpenSudoku(HttpPostedFile file)
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
                        sudoku.Rows[y].Nodes[x] = new SudokuNode(currentValue, new Coordinate(x, y), currentValue > 0, region, nodeInRegion);
                        sudoku.Columns[x].Nodes[y] = new SudokuNode(currentValue, new Coordinate(x, y), currentValue > 0, region, nodeInRegion);
                        sudoku.Regions[region].Nodes[nodeInRegion] = new SudokuNode(currentValue, new Coordinate(x, y), currentValue > 0, region, nodeInRegion);
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
            return sudoku;
        }

        public Sudoku SolveSudoku(Sudoku sudoku)
        {
            var watch = Stopwatch.StartNew();
            // the code that you want to measure comes here
            int y = 0;
            int x = 0;
            int num = 1;
            Coordinate firstNode = null;
            while (y < sudoku.Rows.Length)
            {
                while (x < sudoku.Rows[y].Nodes.Length)
                {
                    if (!sudoku.Rows[y].Nodes[x].IsInitial)
                    {
                        if (firstNode == null)
                        {
                            firstNode = new Coordinate(x, y);
                        }
                        while (num < 10)
                        {
                            sudoku.Rows[y].Nodes[x].Value = num;
                            sudoku.Columns[x].Nodes[y].Value = num;
                            sudoku.Regions[sudoku.Rows[y].Nodes[x].Region].Nodes[sudoku.Rows[y].Nodes[x].NodeInRegion].Value = num;
                            if (!SearchNodeList(sudoku.Rows[y], sudoku.Rows[y].Nodes[x]) &&
                                !SearchNodeList(sudoku.Columns[x], sudoku.Rows[y].Nodes[x]) &&
                                !SearchNodeList(sudoku.Regions[sudoku.Rows[y].Nodes[x].Region], sudoku.Rows[y].Nodes[x]))
                            {
                                break;
                            }
                            num++;
                        }
                    }
                    else
                    {
                        if (!sudoku.Rows[y].Nodes[x].WasChecked)
                        {
                            if (SearchNodeList(sudoku.Rows[y], sudoku.Rows[y].Nodes[x]) ||
                                   SearchNodeList(sudoku.Columns[x], sudoku.Rows[y].Nodes[x]) ||
                                   SearchNodeList(sudoku.Regions[sudoku.Rows[y].Nodes[x].Region], sudoku.Rows[y].Nodes[x]))
                            {
                                sudoku.Solveable = false;
                                return sudoku;
                            }
                        }
                    }
                    if (num < 10)
                    {
                        x++;
                        num = 1;
                    }
                    else
                    {
                        if (firstNode.X == x && firstNode.Y == y)
                        {
                            sudoku.Solveable = false;
                            return sudoku;
                        }
                        sudoku.Rows[y].Nodes[x].Value = 0;
                        sudoku.Columns[x].Nodes[y].Value = 0;
                        sudoku.Regions[sudoku.Rows[y].Nodes[x].Region].Nodes[sudoku.Rows[y].Nodes[x].NodeInRegion].Value = 0;
                        if (x > 0)
                        {
                            x--;
                        }
                        else
                        {
                            y--;
                            x = 8;
                        }
                        while (sudoku.Rows[y].Nodes[x].IsInitial)
                        {
                            if (x > 0)
                            {
                                x--;
                            }
                            else
                            {
                                y--;
                                x = 8;
                            }
                        }
                        num = sudoku.Rows[y].Nodes[x].Value + 1;
                    }
                }
                y++;
                x = 0;
            }
            watch.Stop();
            sudoku.TimeToSolve = watch.ElapsedMilliseconds;
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