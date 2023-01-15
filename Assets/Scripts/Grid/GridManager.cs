namespace CCintron.Grid
{
    public abstract class GridManager
    {
        private readonly int ROWS;
        private readonly int COLUMNS;

        private readonly Cell[] CELLS;
        private readonly Node[] NODES;

        public GridManager(int size)
        {
            ROWS = size;
            COLUMNS = size;
            CELLS = new Cell[ROWS * COLUMNS];
        }

        public GridManager(int rows,int columns)
        {
            ROWS = rows;
            COLUMNS = columns;
            CELLS = new Cell[ROWS * COLUMNS];
        }

        public void Build()
        {
            int index;
            int rowOffset;

            for (int row = 0; row < ROWS; row++)
            {
                rowOffset = row * COLUMNS;

                for (int column = 0; column < COLUMNS; column++)
                {
                    index = rowOffset + column;

                    Cell n = CreateCell(row, column);
                    n.SetPosition(row, column);
                    CELLS[index] = n;
                }
            }
        }

        public void SetNode(Node n, int row, int column)
        {
            //looks at node grid and fills in row/column indices 
        }

        public Cell Find(int row, int column)
        {
            return FindHelper(row, column, 0, CELLS.Length);
        }

        //Binary search to find node
        private Cell FindHelper(int row, int column, int left, int right)
        {
            if (left > right) return null;
            if (left >= CELLS.Length) return null;
            if (right <= -1) return null;

            int mid = (left + right) / 2;

            Cell n = CELLS[mid];
            int compare = CELLS[mid].Compare(row, column);

            if (compare == 0) { return CELLS[mid]; }

            if (compare < 0) { return FindHelper(row, column, mid + 1, right); }
            else { return FindHelper(row, column, left, right - 1); }
        }

        protected abstract Cell CreateCell(int row, int column);
    }
}