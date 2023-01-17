using UnityEngine;
using UnityEngine.UI;

namespace CCintron.GridDemo
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Button btnBridge;
        [SerializeField] private Button btnHouse;
        [SerializeField] private Button btnHouse2;
        [SerializeField] private Button btnLamp;
        [SerializeField] private Button btnWell;

        // Start is called before the first frame update
        void Start()
        {
            //Could definitely make this dynamic but I didn't feel like it
            btnBridge.onClick.AddListener(() => SelectionManager.Select(GamePieceType.Bridge));
            btnHouse.onClick.AddListener(() => SelectionManager.Select(GamePieceType.House));
            btnHouse2.onClick.AddListener(() => SelectionManager.Select(GamePieceType.House2));
            btnLamp.onClick.AddListener(() => SelectionManager.Select(GamePieceType.Lamp));
            btnWell.onClick.AddListener(() => SelectionManager.Select(GamePieceType.Well));
        }
    }
}