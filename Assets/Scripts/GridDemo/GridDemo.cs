using UnityEngine;
using System.Collections.Generic;
using CCintron.Grid;

namespace CCintron.GridDemo
{
    public class GridDemo : MonoBehaviour
    {
        private Grid grid;
        private AssetFactory factory;
        private SelectionManager selectionManager;
        private Node selectedNode;
        private List<Cell> selectedCells;

        void Start()
        {
            grid = new Grid(5);
            grid.Build();

            factory = new AssetFactory();
            selectionManager = new SelectionManager();

            selectedCells = new List<Cell>();


            InputManager.AddListenerMouseMove(OnMouseMoveAction);
            InputManager.AddListenerMouseClick(OnMouseClickAction);
            SelectionManager.AddListenerSelectPiece(OnSelectPieceAction);
        }

        void OnMouseMoveAction(Vector3 v)
        {
            for(int i = 0; i < selectedCells.Count; i++)
            {
                selectedCells[i].UnSelect();
            }

            selectedCells.Clear();

            if (selectedNode == null) return;

            RowColumnPair center = selectedNode.GetCenterPointFromMouseCoord(v.x, v.z);
            RowColumnPair[] coords = selectedNode.GetCoordsFromPoint(center.Row, center.Column);

            for(int i = 0; i < coords.Length; i++)
            {
                RowColumnPair coord = coords[i];
                Cell cell = grid.Find((int)coord.Row, (int)coord.Column);
                if (cell != null)
                {
                    cell.Select();
                    selectedCells.Add(cell);
                }
            }
        }

        void OnMouseClickAction(Vector3 v)
        {
            if (selectedNode == null) return;

            RowColumnPair coord = selectedNode.GetCenterPointFromMouseCoord(v.x, v.z);
            selectedNode.SetPosition(coord.Row, coord.Column);
            selectedNode.Show();

            selectedNode = null;
        }

        void OnSelectPieceAction(GamePieceType piece)
        {
            selectedNode = factory.Get(piece);
            selectedNode.Hide();
        }
    }
}