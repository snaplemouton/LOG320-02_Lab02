using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOG320_02_Lab02.Classes
{
    public class Sudoku
    {
        private SudokuNodeArray[] rows;
        private SudokuNodeArray[] columns;
        private SudokuNodeArray[] regions;

        public Sudoku()
        {
            this.rows = new SudokuNodeArray[9];
            this.columns = new SudokuNodeArray[9];
            this.regions = new SudokuNodeArray[9];

            for (int i = 0; i < 9; i++)
            {
                rows[i] = new SudokuNodeArray(new SudokuNode[9]);
                columns[i] = new SudokuNodeArray(new SudokuNode[9]);
                regions[i] = new SudokuNodeArray(new SudokuNode[9]);
            }
        }
        public Sudoku(SudokuNodeArray[] rows, SudokuNodeArray[] columns, SudokuNodeArray[] regions)
        {
            this.rows = rows;
            this.columns = columns;
            this.regions = regions;
        }

        public SudokuNodeArray[] Rows
        {
            get
            {
                return rows;
            }
            set
            {
                rows = value;
            }
        }
        public SudokuNodeArray[] Columns
        {
            get
            {
                return columns;
            }
            set
            {
                columns = value;
            }
        }
        public SudokuNodeArray[] Regions
        {
            get
            {
                return regions;
            }
            set
            {
                regions = value;
            }
        }
    }

    public class SudokuNodeArray
    {
        private SudokuNode[] nodes;

        public SudokuNodeArray() { }
        public SudokuNodeArray(SudokuNode[] nodes)
        {
            this.nodes = nodes;
        }

        public SudokuNode[] Nodes
        {
            get
            {
                return nodes;
            }
            set
            {
                nodes = value;
            }
        }
    }

    public class SudokuNode
    {
        private int value;
        private Coordinate coordinate;
        private bool isInitial;

        public SudokuNode() { }
        public SudokuNode(int value, Coordinate coordinate, bool isInitial)
        {
            this.value = value;
            this.coordinate = coordinate;
            this.isInitial = isInitial;
        }

        public int Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
            }
        }
        public Coordinate Coordinate
        {
            get
            {
                return coordinate;
            }
            set
            {
                coordinate = value;
            }
        }
        public bool IsInitial
        {
            get
            {
                return isInitial;
            }
            set
            {
                this.isInitial = value;
            }
        }
    }

    public class Coordinate
    {
        private int x;
        private int y;

        public Coordinate() { }
        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public bool Compare(Coordinate coordinateToCompare)
        {
            if (this.x == coordinateToCompare.X && this.y == coordinateToCompare.Y) return true;
            return false;
        }
    }
}