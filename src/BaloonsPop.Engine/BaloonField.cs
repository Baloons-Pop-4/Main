namespace BaloonsPop.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using BaloonsPop.Common.Contracts;

    public class BaloonField : IBaloonsField
    {
        private const int RowsCount = 5;

        private const int ColumnsCount = 10;

        private const int MinBaloonValue = 1;

        private const int MaxBaloonValue = 4;

        private byte[,] baloonsField;

        public BaloonField()
        {
            this.baloonsField = new byte[RowsCount, ColumnsCount];
        }

        public int Columns
        {
            get
            {
                return ColumnsCount;
            }
        }

        public int Rows
        {
            get
            {
                return RowsCount;
            }
        }

        public byte[,] Baloons
        {
            get 
            { 
                return (byte[,])this.baloonsField.Clone(); 
            }
        }

        public byte this[IPoint point]
        {
            get
            {
                return this[point.X, point.Y];
            }
            set
            {
                this[point.X, point.Y] = value;
            }
        }
        public byte this[int row, int column]
        {
            get
            {
                return this.baloonsField[row, column];
            }
            set
            {
                this.baloonsField[row, column] = value;
            }
        }

        public IEnumerator<byte> GetEnumerator()
        {
            foreach (var baloon in this.baloonsField)
            {
                yield return baloon;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        
    }
}
