using System.Collections;
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
    public HUD hud;

    public int score1Star;
    public int score2Star;
    public int score3Star;    

    protected LevelType type;

    protected int currentScore;

    protected bool didWin;

    void Start()
    {
        hud.SetScore(currentScore);
    }

    public LevelType Type
    {
        get { return type; }
    }

    public virtual void GameWin()
    {
        grid.GameOver();
        didWin = true;
        StartCoroutine(WaitForGridFill());
    }

    public virtual void GameLose()
    {        
        grid.GameOver();
        didWin = false;
        StartCoroutine(WaitForGridFill());
    }
    
    public virtual void OnMove()
    {
        Debug.Log("You moved!");
    }

    public virtual void OnPieceCleared(GamePiece piece)
    {
        currentScore += piece.score;
        hud.SetScore(currentScore);
    }

    protected virtual IEnumerator WaitForGridFill()
    {
        while (grid.IsFilling)
        {
            yield return 0;            
        }

        if (didWin)
        {
            hud.OnGameWin(currentScore);
        }
        else
        {
            hud.OnGameLose();
        }
    }
}
