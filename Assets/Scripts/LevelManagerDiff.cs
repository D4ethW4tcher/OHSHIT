using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelManagerDiff : MonoBehaviour
{
    public int currentLevel = 0;
    public Button myButton;
    [SerializeField] private PowerUps filePower;
    private Snake FileSnake;

    void Start()
    {
        myButton.onClick.AddListener(OnButtonClick);
        filePower.WinState = "N";
    }

    void LateUpdate()
    {
        if (filePower.WinState == "Win" || FileSnake.winning == "Win")
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
        filePower.WinState = "Win";
    }
}