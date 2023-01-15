using UnityEngine;

namespace CCintron.GridDemo
{
    public class GridDemo : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Grid grid = new Grid(5);
            grid.Build();

            grid.Find(0, 0).Select();
            grid.Find(4, 4).Select();
        }
    }
}