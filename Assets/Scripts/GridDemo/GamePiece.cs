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

        public override void Show()
        {
            gameObject.SetActive(true);
        }

        public override void Hide()
        {
            gameObject.SetActive(false);
        }

        public override void SetPosition(float x, float y)
        {
            gameObject.transform.position = new Vector3(x, 0, y);
        }
    }
}