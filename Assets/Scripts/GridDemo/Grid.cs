using CCintron.Grid;

namespace CCintron.GridDemo
{
    public class Grid : GridManager
    {
        CellStateFactory stateFactory;

        public Grid(int size) 
            : base(size)
        {
            Init();
        }

        public Grid(int rows, int columns) 
            : base(rows,columns)
        {
            Init();
        }

        void Init()
        {
            stateFactory = new CellStateFactory();
        }

        protected override Cell CreateCell(int row, int column)
        {
            return new GridCell(row, column, stateFactory);
        }
    }
}