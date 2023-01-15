namespace CCintron.Grid
{
    public abstract class Node : INodeComparator
    {
        public readonly int ROW;
        public readonly int COLUMN;

        public Node(int row, int column)
        {
            ROW = row;
            COLUMN = column;
        }

        public int Compare(Node node)
        {
            if (ROW < node.ROW) return -1;
            else if (ROW > node.ROW) return 1;

            if (COLUMN < node.COLUMN) return -1;
            else if (COLUMN > node.COLUMN) return 1;

            return 0;
        }

        public abstract void SetPosition(int x, int y);
        public abstract void Select();
        public abstract void UnSelect();
    }
}