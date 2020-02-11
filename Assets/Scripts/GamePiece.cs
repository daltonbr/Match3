using UnityEngine;

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

    private Grid _grid;

    public Grid GridRef => _grid;

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

    public void Init(int x, int y, Grid grid, PieceType type)
    {
        _x = x;
        _y = y;
        _grid = grid;
        _type = type;
    }

    private void OnMouseEnter()
    {
        _grid.EnterPiece(this);
    }

    private void OnMouseDown()
    {
        _grid.PressPiece(this);
    }

    private void OnMouseUp()
    {
        _grid.ReleasePiece();
    }

    public bool IsMovable()
    {
        return _movableComponent != null;
    }

    public bool IsColored()
    {
        return _colorComponent != null;
    }

    public bool IsClearable()
    {
        return _clearableComponent != null;
    }

}
