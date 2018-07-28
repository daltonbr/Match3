public class ClearColorPiece : ClearablePiece
{

    private ColorPiece.ColorType color;

    public ColorPiece.ColorType Color
    {
        get { return color; }
        set { color = value; }
    }

    public override void Clear()
    {
        base.Clear();

        // Clear color
    }
}
