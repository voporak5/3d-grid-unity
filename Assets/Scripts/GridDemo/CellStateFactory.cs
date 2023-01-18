using CCintron.Grid;

namespace CCintron.GridDemo
{
    public class CellStateFactory
    {
        private CellState stateNormal;
        private CellState stateOpen;
        private CellState stateBlocked;

        public CellStateFactory()
        {
            stateNormal = new CellStateNormal();
            stateOpen = new CellStateOpen();
            stateBlocked = new CellStateBlocked();
        }

        public CellState Get(CellStateType state)
        {
            switch(state)
            {
                case CellStateType.Open:        return stateOpen;
                case CellStateType.Blocked:     return stateBlocked;
                case CellStateType.Normal:
                default:                        return stateNormal;
            }
        }
    }
}
