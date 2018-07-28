using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class Level : MonoBehaviour
{

    public enum LevelType
    {
        TIMER,
        OBSTACLE,
        MOVES,
    };

    // TODO make an assertion and/or get automatically
    public Grid grid;

    public int score1Star;
    public int score2Star;
    public int score3Star;    

    protected LevelType type;

    protected int currentScore;

    public LevelType Type
    {
        get { return type; }
    }

    public virtual void GameWin()
    {
        Debug.Log("You Win!");
        grid.GameOver();
    }

    public virtual void GameLose()
    {
        Debug.Log("You Lose!");
        grid.GameOver();
    }
    
    public virtual void OnMove()
    {
        Debug.Log("You moved!");
    }

    public virtual void OnPieceCleared(GamePiece piece)
    {
        currentScore += piece.score;
        Debug.Log("Score: " + currentScore);
    }

}
