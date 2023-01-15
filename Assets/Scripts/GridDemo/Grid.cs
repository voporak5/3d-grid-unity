using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CCintron.Grid;

namespace CCintron.GridDemo
{
    public class Grid : GridManager
    {
        //I'm using a full 1x1 cube for my prefab, but painting
        //a full terrain with cubes is difficult so you could
        //consider the using a 2D sprite as your node that is
        //layed on top of a textured plane
        private GameObject nodePrefab;
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
            nodePrefab = (GameObject)Resources.Load("Prefabs/Node");
            nodeNeutralMat = (Material)Resources.Load("Materials/GridNeutral");
            nodeSelectedMat = (Material)Resources.Load("Materials/GridSelected");
        }

        protected override Node CreateNode(int row, int column)
        {
            return new GridNode(row, column, nodePrefab, nodeNeutralMat, nodeSelectedMat);
        }
    }
}