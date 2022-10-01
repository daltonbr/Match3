namespace Match3
{
    public class LevelObstacles : Level
    {

        public int numMoves;
        public PieceType[] obstacleTypes;

        private const int ScorePerPieceCleared = 1000;
    
        private int _movesUsed = 0;
        private int _numObstaclesLeft;

        private void Start ()
        {
            type = LevelType.Obstacle;

            for (int i = 0; i < obstacleTypes.Length; i++)
            {
                _numObstaclesLeft += gameGrid.GetPiecesOfType(obstacleTypes[i]).Count;
            }

            hud.SetLevelType(type);
            hud.SetScore(currentScore);
            hud.SetTarget(_numObstaclesLeft);
            hud.SetRemaining(numMoves);
        }

        public override void OnMove()
        {
            _movesUsed++;

            hud.SetRemaining(numMoves - _movesUsed);

            if (numMoves - _movesUsed == 0 && _numObstaclesLeft > 0)
            {
                GameLose();
            }
        }

        public override void OnPieceCleared(GamePiece piece)
        {
            base.OnPieceCleared(piece);

            for (int i = 0; i < obstacleTypes.Length; i++)
            {
                if (obstacleTypes[i] != piece.Type) continue;
            
                _numObstaclesLeft--;
                hud.SetTarget(_numObstaclesLeft);
                if (_numObstaclesLeft != 0) continue;
            
                currentScore += ScorePerPieceCleared * (numMoves - _movesUsed);
                hud.SetScore(currentScore);
                GameWin();
            }
        }
    }
}
