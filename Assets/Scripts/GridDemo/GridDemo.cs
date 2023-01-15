using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CCintron.Grid;

namespace CCintron.GridDemo
{
    public class GridDemo : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Grid grid = new Grid(5);
            grid.Build();
        }
    }
}