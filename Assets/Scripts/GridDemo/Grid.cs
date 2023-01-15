using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CCintron.Grid;

namespace CCintron.GridDemo
{
    public class Grid : GridManager
    {
        private Material nodeNeutralMat;
        private Material nodeSelectedMat;

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
            nodeNeutralMat = (Material)Resources.Load("Materials/GridNeutral");
            nodeSelectedMat = (Material)Resources.Load("Materials/GridSelected");
        }

        protected override Node CreateNode(int row, int column)
        {
            return new GridNode(row, column, nodeNeutralMat, nodeSelectedMat);
        }
    }
}