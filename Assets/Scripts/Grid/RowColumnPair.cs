namespace CCintron.Grid
{
    public class RowColumnPair
    {
        public int Row { get; private set; }
        public int Column { get; private set; }

        public RowColumnPair(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}