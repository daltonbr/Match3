public class ClearColorPiece : ClearablePiece
{
    private ColorType _color;

    public ColorType Color
    {
        get => _color;
        set => _color = value;
    }

    public override void Clear()
    {
        base.Clear();

        piece.GridRef.ClearColor(_color);
    }
}
