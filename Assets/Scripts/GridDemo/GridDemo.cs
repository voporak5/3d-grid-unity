using UnityEngine;
using CCintron.Grid;

namespace CCintron.GridDemo
{
    public class GridDemo : MonoBehaviour
    {
        private Grid grid;
        private Node selected;
        private Node prev;

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
            Node node = grid.Find(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.z));
            
            if(node == null)
            {
                prev = selected;
                selected = null;
            }
            else if (node != selected)
            {
                node.Select();
                prev = selected;
                selected = node;
            }

            if(prev != null)
            {
                prev.UnSelect();
                prev = null;
            }
        }
    }
}