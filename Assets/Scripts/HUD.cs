using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    // TODO get this automatically and/or make an assertion
    public Level level;
    public GameOver gameOver;

    public Text remainingText;
    public Text remainingSubText;
    public Text targetText;
    public Text targetSubtext;
    public Text scoreText;
    public Image[] stars;

    private int starIdx = 0;    

    void Start ()
	{
	    for (int i = 0; i < stars.Length; i++)
	    {
	        if (i == starIdx)
	        {
	            stars[i].enabled = true;
	        }
	        else
	        {
	            stars[i].enabled = false;
	        }
	    }
	}

    public void SetScore(int score)
    {
        scoreText.text = score.ToString();

        int visibleStar = 0;

        if (score >= level.score1Star && score < level.score2Star)
        {
            visibleStar = 1;
        }
        else if  (score >= level.score2Star && score < level.score3Star)
        {
            visibleStar = 2;
        }
        else if (score >= level.score3Star)
        {
            visibleStar = 3;
        }

        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].enabled = (i == visibleStar);
            //if (i == visibleStar)
            //{
            //    stars[i].enabled = true;
            //}
            //else
            //{
            //    stars[i].enabled = false;
            //}
        }

        starIdx = visibleStar;
    }

    public void SetTarget(int target)
    {
        targetText.text = target.ToString();
    }

    public void SetRemaining(int remaining)
    {
        remainingText.text = remaining.ToString();
    }

    public void SetRemaining(string remaining)
    {
        remainingText.text = remaining;
    }

    public void SetLevelType(Level.LevelType type)
    {
        if (type == Level.LevelType.MOVES)
        {
            remainingSubText.text = "moves remaining";
            targetSubtext.text = "target score";
        }
        else if (type == Level.LevelType.OBSTACLE)
        {
            remainingSubText.text = "moves remaining";
            targetSubtext.text = "bubbles remaining";
        }
        else if (type == Level.LevelType.TIMER)
        {
            remainingSubText.text = "time remaining";
            targetSubtext.text = "target score";
        }
    }

    public void OnGameWin(int score)
    {
        gameOver.ShowWin(score, starIdx);        
    }

    public void OnGameLose()
    {
        gameOver.ShowLose();        
    }
}
