using UnityEngine;
using CCintron.Grid;

namespace CCintron.GridDemo
{
    public class GridDemo : MonoBehaviour
    {
        private Grid grid;
        private Cell selected;
        private Cell prev;

        // Start is called before the first frame update
        void Start()
        {
            grid = new Grid(5);
            grid.Build();

            //grid.Find(0, 0).Select();
            //grid.Find(4, 4).Select();
            InputManager.AddListener(OnMouseMoveAction);
        }

        void OnMouseMoveAction(Vector3 v)
        {
            Cell cell = grid.Find(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.z));
            
            if(cell == null)
            {
                prev = selected;
                selected = null;
            }
            else if (cell != selected)
            {
                cell.Select();
                prev = selected;
                selected = cell;
            }

            if(prev != null)
            {
                prev.UnSelect();
                prev = null;
            }
        }
    }
}