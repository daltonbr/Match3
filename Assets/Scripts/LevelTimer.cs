using UnityEngine;

public class LevelTimer : Level
{

    public int timeInSeconds;
    public int targetScore;

    private float timer;
    private bool timeOut = false;


	void Start ()
	{
	    type = LevelType.TIMER;

        Debug.Log("Time: " + timeInSeconds + "seconds. Target score: " + targetScore);
	}

    // TODO convert this into a Coroutine for efficiency
    void Update()
    {
        if (timeOut) { return; }

        timer += Time.deltaTime;

        if (timeInSeconds - timer <= 0)
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
