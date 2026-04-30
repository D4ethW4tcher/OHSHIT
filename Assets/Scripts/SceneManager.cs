using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneManager : MonoBehaviour
{
    private int CurrentLevel = 0;
    public Button myButton;
    public PowerUps FilePower;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myButton.onClick.AddListener(OnButtonClick);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (CurrentLevel == 0 && FilePower.WinState == "Win"){
            SceneManager.LoadScene("SampleScene");
            CurrentLevel += 1;
        }
        if (CurrentLevel == 1 && FilePower.WinState == "Win"){
            SceneManager.LoadScene("SecoundLevel");
            CurrentLevel += 1;
        }
    }
    void OnButtonClick(){
        FilePower.WinState = "Win";
    }
}
