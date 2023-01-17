using UnityEngine;
using CCintron.Grid;

namespace CCintron.GridDemo
{
    public class GamePiece : Node
    {
        private GameObject gameObject;

        public GamePiece(string pattern, GameObject prefab)
        {
            Init(pattern);
            gameObject = Object.Instantiate(prefab);
        }

        public override void SetPosition(int x, int y)
        {
            gameObject.transform.position = new Vector3(x, 0, y);
        }
    }
}