namespace Match3
{
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

            piece.GameGridRef.ClearColor(_color);
        }
    }
}
