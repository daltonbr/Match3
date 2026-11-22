using UnityEngine;
using UnityEngine.EventSystems;

namespace Match3
{
    public class GamePiece : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerUpHandler
    {
        public int score;

        private int _x;
        private int _y;

        public int X
        {
            get => _x;
            set { if (IsMovable()) { _x = value; } }
        }

        public int Y
        {
            get => _y;
            set { if (IsMovable()) { _y = value; } }
        }
    
        private PieceType _type;

        public PieceType Type => _type;

        private GameGrid _gameGrid;

        public GameGrid GameGridRef => _gameGrid;

        private MovablePiece _movableComponent;

        public MovablePiece MovableComponent => _movableComponent;

        private ColorPiece _colorComponent;

        public ColorPiece ColorComponent => _colorComponent;

        private ClearablePiece _clearableComponent;

        public ClearablePiece ClearableComponent => _clearableComponent;

        private void Awake()
        {
            _movableComponent = GetComponent<MovablePiece>();
            _colorComponent = GetComponent<ColorPiece>();
            _clearableComponent = GetComponent<ClearablePiece>();
        }

        public void Init(int x, int y, GameGrid gameGrid, PieceType type)
        {
            _x = x;
            _y = y;
            _gameGrid = gameGrid;
            _type = type;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                _gameGrid.PressPiece(this, eventData.pointerId);
            }
        }

        public void OnPointerEnter(PointerEventData eventData) =>
            _gameGrid.EnterPiece(this, eventData.pointerId);

        public void OnPointerUp(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left) return;

            // The press target receives release even when the pointer leaves the board.
            GameObject hit = eventData.pointerCurrentRaycast.gameObject;
            GamePiece releasedPiece = hit ? hit.GetComponentInParent<GamePiece>() : null;
            _gameGrid.EnterPiece(releasedPiece, eventData.pointerId);
            _gameGrid.ReleasePiece(eventData.pointerId);
        }

        public bool IsMovable() => _movableComponent != null;

        public bool IsColored() => _colorComponent != null;

        public bool IsClearable() => _clearableComponent != null;
    }
}
