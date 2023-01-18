using UnityEngine;
using CCintron.Grid;

namespace CCintron.GridDemo
{
    public class GridCell : Cell
    {
        private Renderer renderer;
        private GameObject gameObject;
        private CellStateFactory stateFactory;

        public GridCell(int row, int column, CellStateFactory stateFactory) 
            : base(row, column)
        {
            this.stateFactory = stateFactory;

            //I'm using a full 1x1 cube for my prefab, but painting
            //a full terrain with cubes is difficult so you could
            //consider the using a 2D sprite as your node that is
            //layed on top of a textured plane.
            gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            renderer = gameObject.GetComponent<Renderer>();

            SetState(CellStateType.Normal);
        }

        public override void SetPosition(int x, int y)
        {
            gameObject.transform.position = new Vector3(x, 0, y);
        }

        public override void SetState(CellStateType state)
        {
            stateFactory.Get(state).SetState(renderer);
        }
    }
}