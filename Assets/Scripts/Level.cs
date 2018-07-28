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
    }

    public virtual void GameLose()
    {
        Debug.Log("You Lose!");
    }
    
    public virtual void OnMove()
    {

    }

    public virtual void OnPieceCleared(GamePiece piece)
    {
        currentScore += piece.score;
        Debug.Log("Score: " + currentScore);
    }

}
