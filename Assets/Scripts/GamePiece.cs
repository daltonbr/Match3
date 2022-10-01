using UnityEngine;

namespace Match3
{
    public class GamePiece : MonoBehaviour
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

        private void OnMouseEnter() => _gameGrid.EnterPiece(this);

        private void OnMouseDown() => _gameGrid.PressPiece(this);

        private void OnMouseUp() => _gameGrid.ReleasePiece();

        public bool IsMovable() => _movableComponent != null;

        public bool IsColored() => _colorComponent != null;

        public bool IsClearable() => _clearableComponent != null;
    }
}
