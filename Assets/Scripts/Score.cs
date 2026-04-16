using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private static Score instance;

    public static Score Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = new GameObject("GameScore");
                instance = obj.AddComponent<Score>();
                instance.Initialize();
            }
            return instance;
        }
    }

    private Text gameScoreText;

    public void Initialize()
    {
        Debug.Log("Score initialized");

        // Create Canvas
        GameObject canvasObj = new GameObject("ScoreCanvas");
        Canvas canvas = canvasObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        canvasObj.AddComponent<CanvasScaler>();
        canvasObj.AddComponent<GraphicRaycaster>();

        canvas.sortingOrder = 100;

        // Create Text object
        GameObject textObj = new GameObject("ScoreText");
        textObj.transform.SetParent(canvasObj.transform, false);

        gameScoreText = textObj.AddComponent<Text>();

        gameScoreText.text = "Score: 0";
        gameScoreText.fontSize = 24;
        gameScoreText.color = Color.white;
        gameScoreText.alignment = TextAnchor.UpperLeft;

        // Font (safe runtime option)
        gameScoreText.font = Font.CreateDynamicFontFromOSFont("Arial", 24);

        // Position (top-left)
        RectTransform rect = gameScoreText.GetComponent<RectTransform>();
        rect.anchorMin = new Vector2(0, 1);
        rect.anchorMax = new Vector2(0, 1);
        rect.pivot = new Vector2(0, 1);
        rect.anchoredPosition = new Vector2(10, -10);
    }

    public void UpdateScoreText(int score)
    {
        if (gameScoreText == null)
        {
            Debug.LogWarning("Score text not initialized yet.");
            return;
        }

        gameScoreText.text = "Score: " + score;
    }

    private void OnApplicationQuit()
    {
        instance = null;
    }
}