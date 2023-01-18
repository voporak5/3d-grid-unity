using UnityEngine;

namespace CCintron.GridDemo
{
    public abstract class CellState 
    {
        Material material;

        protected void Init(Material material)
        {
            this.material = material;
        }

        public void SetState(Renderer context)
        {
            context.material = material;
        }
    }
}