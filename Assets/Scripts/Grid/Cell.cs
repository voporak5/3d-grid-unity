namespace CCintron.Grid
{
    public abstract class Cell : ICellComparator
    {
        public readonly int ROW;
        public readonly int COLUMN;

        public Cell(int row, int column)
        {
            ROW     =   row;
            COLUMN  =   column;
        }

        public int Compare(int row, int column)
        {
            if (ROW < row) return -1;
            else if (ROW > row) return 1;

            if (COLUMN < column) return -1;
            else if (COLUMN > column) return 1;

            return 0;
        }

        public abstract void SetPosition(int x, int y);
        public abstract void SetState(CellStateType state);
    }
}