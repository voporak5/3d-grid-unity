using System;

namespace CCintron.GridDemo
{
    public class SelectionManager
    {
        private static SelectionManager Instance;

        private Action<GamePieceType> SelectPieceAction;

        public SelectionManager()
        {
            Instance = this;
        }

        public static void Select(GamePieceType piece)
        {
            Instance.SelectPieceAction?.Invoke(piece);
        }

        public static void AddListenerSelectPiece(Action<GamePieceType> onPieceSelected)
        {
            Instance.SelectPieceAction += onPieceSelected;
        }

        public static void RemoveListenerSelectPiece(Action<GamePieceType> onPieceSelected)
        {
            Instance.SelectPieceAction -= onPieceSelected;
        }
    }
}