using UnityEngine;

namespace CCintron.GridDemo
{
    public class CellStateOpen : CellState
    {
        public CellStateOpen()
        {
            Material material = (Material)Resources.Load("Materials/GridOpen");
            Init(material);
        }
    }
}