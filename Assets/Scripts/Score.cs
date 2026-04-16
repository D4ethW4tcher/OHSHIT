using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{
    private static Score instance = null;
    private GUIText gameScoreText;

    public static Score Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("GameScore").AddComponent<Score>();
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
        print("Score Instance destroyed");
        instance = null;
    }

    public void UpdateScoreText(string appendString)
    {
        gameScoreText.text = "";
        gameScoreText.text = "Score: " + appendString;
    }

    public void Initialize()
    {
        print("Score initialized");
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        transform.localScale = Vector3.one;

        gameScoreText = gameObject.AddComponent<GUIText>();
        gameScoreText.text = "Score: ";
        gameScoreText.pixelOffset = new Vector2(10, 758);
    }
}