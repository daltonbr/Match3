using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    // TODO get this automatically and/or make an assertion
    public Level level;

    public Text remainingText;
    public Text remainingSubText;
    public Text targetText;
    public Text targetSubtext;
    public Text scoreText;
    public Image[] stars;

    private int starIdx = 0;

    private bool isGameOver = false;

    void Start ()
	{
		
	}

}
