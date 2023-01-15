using UnityEngine;
using CCintron.Grid;

namespace CCintron.GridDemo
{
    public class Grid : GridManager
    {
        private Material cellNeutralMat;
        private Material cellSelectedMat;

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
            cellNeutralMat = (Material)Resources.Load("Materials/GridNeutral");
            cellSelectedMat = (Material)Resources.Load("Materials/GridSelected");
        }

        protected override Cell CreateCell(int row, int column)
        {
            return new GridCell(row, column, cellNeutralMat, cellSelectedMat);
        }
    }
}