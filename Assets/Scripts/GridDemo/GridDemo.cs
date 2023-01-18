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
        private bool canSetNode;

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
                selectedCells[i].SetState(CellStateType.Normal);
            }

            selectedCells.Clear();

            if (selectedNode == null) return;

            RowColumnPair center = selectedNode.GetCenterPointFromMouseCoord(v.x, v.z);
            RowColumnPair[] coords = selectedNode.GetCoordsFromPoint(center.Row, center.Column);
            int nCoords = coords.Length;
            int nCellsFound = 0;

            for(int i = 0; i < coords.Length; i++)
            {
                RowColumnPair coord = coords[i];
                Cell cell = grid.Find((int)coord.Row, (int)coord.Column);
                if (cell != null)
                {
                    nCellsFound++;
                    selectedCells.Add(cell);
                }
            }

            if(nCellsFound == nCoords)
            {
                selectedNode.SetPosition(center.Row, center.Column);
                selectedNode.Show();
                canSetNode = true;

                for (int i = 0; i < selectedCells.Count; i++)
                {
                    Cell cell = selectedCells[i];
                    CellStateType state = grid.GetCanSetNodeInCell(cell) ? CellStateType.Open : CellStateType.Blocked;
                    cell.SetState(state);
                    if (state == CellStateType.Blocked)
                    {
                        canSetNode = false;
                        selectedNode.Hide();
                    }
                }
            }
            else
            {
                selectedNode.Hide();
            }
        }

        void OnMouseClickAction(Vector3 v)
        {
            if (selectedNode == null) return;

            if(canSetNode)
            {
                for (int i = 0; i < selectedCells.Count; i++)
                {
                    grid.SetNode(selectedNode, selectedCells[i]);
                }
            }
            else
            {
                selectedNode.Hide();
            }

            selectedNode = null;
        }

        void OnSelectPieceAction(GamePieceType piece)
        {
            selectedNode = factory.Get(piece);
            selectedNode.Hide();
        }
    }
}