using UnityEngine;

public class LevelMoves : Level
{

    public int numMoves;
    public int targetScore;

    private int movesUsed = 0;

    void Start()
    {
        type = LevelType.MOVES;

        Debug.Log("Number of moves: " + numMoves +
                  " Target score: " + targetScore);
    }

    public override void OnMove()
    {
        movesUsed++;

        Debug.Log("Moves remaining: " + (numMoves - movesUsed));

        if (numMoves - movesUsed == 0)
        {
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
}
