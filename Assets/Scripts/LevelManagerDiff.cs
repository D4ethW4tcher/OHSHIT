using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelManagerDiff : MonoBehaviour
{
    private int currentLevel = 0;
    public Button myButton;
    [SerializeField] private PowerUps filePower;

    void Start()
    {
        myButton.onClick.AddListener(OnButtonClick);
        filePower.WinState = "N";
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
        filePower.WinState = "N";
    }

    public void OnButtonClick()
    {
        filePower.WinState = "Win";
    }
}