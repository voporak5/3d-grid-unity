using UnityEngine;
using CCintron.Grid;

namespace CCintron.GridDemo
{
    public class GridDemo : MonoBehaviour
    {
        private Grid grid;
        private Cell selected;
        private Cell prev;
        private AssetFactory factory;

        // Start is called before the first frame update
        void Start()
        {
            grid = new Grid(5);
            grid.Build();

            factory = new AssetFactory();

            //grid.Find(0, 0).Select();
            //grid.Find(4, 4).Select();
            InputManager.AddListenerMouseMove(OnMouseMoveAction);
            InputManager.AddListenerMouseClick(OnMouseClickAction);
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

        void OnMouseClickAction(Vector3 v)
        {
            Node n = factory.Get(GamePieceType.House);
            n.SetPosition(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.z));
        }
    }
}