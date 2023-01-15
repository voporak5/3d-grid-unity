using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        protected abstract Node CreateNode(int row, int column);
    }
}