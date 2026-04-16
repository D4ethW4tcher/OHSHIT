using UnityEngine;
using System.Collections;

public class Lives : MonoBehaviour
{
    private static Lives instance = null;
    private GUIText gameLivesText;

    public static Lives Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("GameLives").AddComponent<Lives>();
            }
            return instance;
        }
    }

    public void OnApplicationQuit()
    {
        DestroyInstance();
    }

    public void DestroyInstance()
    {
        print("Lives Instance destroyed");
        instance = null;
    }

    public void UpdateLivesText(string appendString)
    {
        gameLivesText.text = "";
        gameLivesText.text = "Lives: " + appendString;
    }

    public void Initialize()
    {
        print("Lives initialized");
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        transform.localScale = Vector3.one;

        gameLivesText = gameObject.AddComponent<GUIText>();
        gameLivesText.text = "Lives: ";
        gameLivesText.pixelOffset = new Vector2(944, 758);
    }
}