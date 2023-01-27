using UnityEngine;

namespace CCintron.GridDemo
{
    public abstract class CellState 
    {
        Material material;

        public CellState(string path)
        {
            material = (Material)Resources.Load(path);
        }

        public void SetState(Renderer context)
        {
            context.material = material;
        }
    }
}