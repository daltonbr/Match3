public class LevelMoves : Level
{

    public int numMoves;
    public int targetScore;

    private int _movesUsed = 0;

    private void Start()
    {
        type = LevelType.MOVES;

        hud.SetLevelType(type);
        hud.SetScore(currentScore);
        hud.SetTarget(targetScore);
        hud.SetRemaining(numMoves);
    }

    public override void OnMove()
    {
        _movesUsed++;

        hud.SetRemaining(numMoves - _movesUsed);

        if (numMoves - _movesUsed != 0) return;
        
        if (currentScore >= targetScore)
        {
            GameWin();
        }
        else
        {
            GameLose();
        }
    }
}
