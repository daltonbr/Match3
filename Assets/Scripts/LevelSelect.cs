using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    [System.Serializable]
    public struct ButtonPlayerPrefs
    {
        public GameObject gameObject;
        public string playerPrefKey;
    };

    public ButtonPlayerPrefs[] buttons;

    private void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int score = PlayerPrefs.GetInt(buttons[i].playerPrefKey, 0);

            for (int starIdx = 1; starIdx <= 3; starIdx++)
            {
                Transform star = buttons[i].gameObject.transform.Find("star" + starIdx);
                star.gameObject.SetActive(starIdx <= score);                
            }
        }
    }

    public void OnButtonPress(string levelName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
    }
}
