namespace BaloonsPop.Common.Contracts
{
    using System.Collections.Generic;

    public interface IBaloonsField : IEnumerable<byte>
    {
        byte[,] Baloons { get; }
        int Rows { get; }
        int Columns { get; }
        byte this[IPoint point] { get; set; }
        byte this[int row, int column] { get; set; }
    }
}