namespace CCintron.Grid
{
    public abstract class GridManager
    {
        private readonly int ROWS;
        private readonly int COLUMNS;

        private readonly Node[] NODES;

        public GridManager(int size)
        {
            ROWS = size;
            COLUMNS = size;
            NODES = new Node[ROWS * COLUMNS];
        }

        public GridManager(int rows,int columns)
        {
            ROWS = rows;
            COLUMNS = columns;
            NODES = new Node[ROWS * COLUMNS];
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

                    Node n = CreateNode(row, column);
                    n.SetPosition(row, column);
                    NODES[index] = n;
                }
            }
        }

        public Node Find(int row, int column)
        {
            return FindHelper(row, column, 0, NODES.Length);
        }

        //Binary search to find node
        private Node FindHelper(int row, int column, int left, int right)
        {
            if (left > right) { return null; }
            
            int mid = (left + right) / 2;

            Node n = NODES[mid];
            int compare = NODES[mid].Compare(row, column);

            if (compare == 0) { return NODES[mid]; }

            if (compare < 0) { return FindHelper(row, column, mid + 1, right); }
            else { return FindHelper(row, column, left, right - 1); }
        }

        protected abstract Node CreateNode(int row, int column);
    }
}