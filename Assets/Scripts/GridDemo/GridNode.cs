using System.Collections;
using System.Collections.Generic;
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

        public GridNode(int row, int column, GameObject prefab,Material neutral, Material selected) 
            : base(row, column)
        {
            this.neutral = neutral;
            this.selected = selected;

            gameObject = Object.Instantiate(prefab) as GameObject;
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