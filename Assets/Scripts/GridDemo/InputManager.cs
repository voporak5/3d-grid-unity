using System;
using UnityEngine;

namespace CCintron.GridDemo
{
    public class InputManager : MonoBehaviour
    {
        private static InputManager Instance;

        private Action<Vector3> MouseMoveAction;

        //Shift down by -0.5 because cubes are centered at 0 along Y axis
        //and extend by 0.5 units.
        Plane plane = new Plane(Vector3.up, -0.5f);
        public Vector3 worldPosition;

        private void Awake()
        {
            Instance = this;
        }


        // Update is called once per frame
        void Update()
        {
            //Lightweight Unity method
            //https://gamedevbeginner.com/how-to-convert-the-mouse-position-to-world-space-in-unity-2d-3d/
            //If you want to do it manually then you will need a combination of the math for
            //screenpoint to worldpoint to create a segment and then use the math for
            //Segment-Plane intersection to get the point of intersection (Linear algebra)
            float distance;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out distance))
            {
                worldPosition = ray.GetPoint(distance);
            }

            MouseMoveAction?.Invoke(worldPosition);
        }

        public static void AddListener(Action<Vector3> onMouseMove)
        {
            Instance.MouseMoveAction += onMouseMove;
        }

        public static void RemoveListener(Action<Vector3> onMouseMove)
        {
            Instance.MouseMoveAction -= onMouseMove;
        }
    }
}