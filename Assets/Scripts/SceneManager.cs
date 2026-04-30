using UnityEngine;
using UnityEngine.SceneManagement;  // Keep the using directive
using UnityEngine.UI;

// Renamed to avoid conflict with UnityEngine.SceneManagement.SceneManager
public class LevelManager : MonoBehaviour
{
    private int currentLevel = 0;
    public Button myButton;
    public PowerUps filePower;

    void Start()
    {
        myButton.onClick.AddListener(OnButtonClick);
    }

    void LateUpdate()
    {
        if (filePower.WinState == "Win")
        {
            LoadNextLevel();
        }
    }

    void LoadNextLevel()
    {
        // Reset win state first to prevent re-triggering
        filePower.WinState = "";

        if (currentLevel == 0)
        {
            currentLevel++;
            SceneManager.LoadScene("SampleScene");
        }
        else if (currentLevel == 1)
        {
            currentLevel++;
            SceneManager.LoadScene("SecoundLevel");  // kept your spelling
        }
    }

    void OnButtonClick()
    {
        filePower.WinState = "Win";
    }
}