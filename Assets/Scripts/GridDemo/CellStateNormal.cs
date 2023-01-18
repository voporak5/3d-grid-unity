using UnityEngine;

namespace CCintron.GridDemo
{
    public class CellStateNormal : CellState
    {
        public CellStateNormal()
        {
            Material material = (Material)Resources.Load("Materials/GridNormal");
            Init(material);
        }
    }
}