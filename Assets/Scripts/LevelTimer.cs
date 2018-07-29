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

        hud.SetLevelType(type);
        hud.SetScore(currentScore);
        hud.SetTarget(targetScore);
        hud.SetRemaining(string.Format("{0}:{1:00}", timeInSeconds/60, timeInSeconds % 60));
	}

    // TODO convert this into a Coroutine for efficiency
    void Update()
    {
        if (timeOut) { return; }

        timer += Time.deltaTime;
        hud.SetRemaining(string.Format("{0}:{1:00}", (int)Mathf.Max((timeInSeconds - timer) / 60, 0), (int)Mathf.Max((timeInSeconds - timer) % 60, 0)));

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
