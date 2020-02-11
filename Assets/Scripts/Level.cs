using System.Collections;
using UnityEngine;

public class Level : MonoBehaviour
{
    // TODO make an assertion and/or get automatically
    public Grid grid;
    public HUD hud;

    public int score1Star;
    public int score2Star;
    public int score3Star;    

    protected LevelType type;

    protected int currentScore;

    private bool _didWin;

    private void Start()
    {
        hud.SetScore(currentScore);
    }

    public LevelType Type => type;

    public virtual void GameWin()
    {
        grid.GameOver();
        _didWin = true;
        StartCoroutine(WaitForGridFill());
    }

    public virtual void GameLose()
    {        
        grid.GameOver();
        _didWin = false;
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
            yield return null;
        }

        if (_didWin)
        {
            hud.OnGameWin(currentScore);
        }
        else
        {
            hud.OnGameLose();
        }
    }
}
