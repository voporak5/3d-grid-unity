using UnityEngine;
using CCintron.Grid;

namespace CCintron.GridDemo
{
    public class GridNode : Node
    {
        private Material neutral;
        private Material selected;
        private Renderer renderer;
        private GameObject gameObject;

        public GridNode(int row, int column,Material neutral, Material selected) 
            : base(row, column)
        {
            this.neutral = neutral;
            this.selected = selected;

            //I'm using a full 1x1 cube for my prefab, but painting
            //a full terrain with cubes is difficult so you could
            //consider the using a 2D sprite as your node that is
            //layed on top of a textured plane.
            gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            renderer = gameObject.GetComponent<Renderer>();

            UnSelect();
        }

        public override void SetPosition(int x, int y)
        {
            gameObject.transform.position = new Vector3(x, 0, y);
        }

        public override void Select()
        {
            renderer.material = selected;
        }        

        public override void UnSelect()
        {
            renderer.material = neutral;
        }
    }
}