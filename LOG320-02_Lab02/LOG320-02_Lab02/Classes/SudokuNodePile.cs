using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOG320_02_Lab02.Classes
{
    public class SudokuNodePile
    {
        SudokuNodePileNode head;
        SudokuNodePileNode tail;

        
        public SudokuNodePile() { }
        public SudokuNodePile(SudokuNode node)
        {
            SudokuNodePileNode n = new SudokuNodePileNode(node);
            this.head = n;
            this.tail = n;
        }
        public SudokuNodePile(SudokuNodePileNode node)
        {
            this.head = node;
            this.tail = node;
        }

        public SudokuNodePileNode Head
        {
            get
            {
                return head;
            }
            set
            {
                this.head = value;
            }
        }
        public SudokuNodePileNode Tail
        {
            get
            {
                return tail;
            }
            set
            {
                this.tail = value;
            }
        }
    }

    public class SudokuNodePileNode : SudokuNode
    {
        SudokuNode next;
        SudokuNode previous;

        public SudokuNodePileNode() : base() { }
        public SudokuNodePileNode(SudokuNode node)
        {
            base.Value = node.Value;
            base.Coordinate = node.Coordinate;
            this.next = null;
            this.previous = null;
        }
        public SudokuNodePileNode(int value, Coordinate coordinate)
        {
            base.Value = value;
            base.Coordinate = coordinate;
            this.next = null;
            this.previous = null;
        }

        public SudokuNode Next
        {
            get
            {
                return next;
            }
            set
            {
                this.next = value;
            }
        }
        public SudokuNode Previous
        {
            get
            {
                return previous;
            }
            set
            {
                this.previous = value;
            }
        }
    }
}