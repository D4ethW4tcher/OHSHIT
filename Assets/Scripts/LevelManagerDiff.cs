using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelManagerDiff : MonoBehaviour
{
    public int currentLevel = 0;
    public Button myButton;
    private PowerUps FilePower;
    private Snake FileSnake;

    void Start()
    {
        myButton.onClick.AddListener(OnButtonClick);
        FilePower.WinState = "N";
    }

    void LateUpdate()
    {
        if (FilePower.WinState == "Win")
        {
            LoadNextLevel();
        }
        if (FileSnake.winning == "Win")
        {
            LoadNextLevel();
        }
    }


    public void LoadNextLevel()
    {
        // Reset win state first to prevent re-triggering
        

        if (currentLevel == 0)
        {
            currentLevel++;
            SceneManager.LoadScene("LevelOne");
        }
        else if (currentLevel == 1)
        {
            currentLevel++;
            SceneManager.LoadScene("LevelTwo");
        }
        FileSnake.winning = "N";
    }

    public void OnButtonClick()
    {
        FilePower.WinState = "Win";
    }
}