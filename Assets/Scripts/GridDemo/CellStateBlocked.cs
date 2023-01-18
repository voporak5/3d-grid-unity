using UnityEngine;

namespace CCintron.GridDemo
{
    public class CellStateBlocked : CellState
    {
        public CellStateBlocked()
        {
            Material material = (Material)Resources.Load("Materials/GridBlocked");
            Init(material);
        }
    }
}