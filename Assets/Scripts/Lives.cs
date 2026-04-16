using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    private static Lives instance;

    public static Lives Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = new GameObject("LivesManager");
                instance = obj.AddComponent<Lives>();
                instance.Initialize();
            }
            return instance;
        }
    }

    private Text gameLivesText;

    public void Initialize()
    {
        Debug.Log("Lives initialized");

        // Create Canvas
        GameObject canvasObj = new GameObject("LivesCanvas");
        Canvas canvas = canvasObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        canvasObj.AddComponent<CanvasScaler>();
        canvasObj.AddComponent<GraphicRaycaster>();

        // Optional: ensure UI renders on top
        canvas.sortingOrder = 100;

        // Create Text
        GameObject textObj = new GameObject("LivesText");
        textObj.transform.SetParent(canvasObj.transform, false);

        gameLivesText = textObj.AddComponent<Text>();

        gameLivesText.text = "Lives: 3";
        gameLivesText.fontSize = 24;
        gameLivesText.color = Color.white;
        gameLivesText.alignment = TextAnchor.UpperRight;

        // Font (safe modern approach)
        gameLivesText.font = Font.CreateDynamicFontFromOSFont("Arial", 24);

        // Position
        RectTransform rect = gameLivesText.GetComponent<RectTransform>();
        rect.anchorMin = new Vector2(1, 1);
        rect.anchorMax = new Vector2(1, 1);
        rect.pivot = new Vector2(1, 1);
        rect.anchoredPosition = new Vector2(-20, -20);
    }

    public void UpdateLivesText(int lives)
    {
        if (gameLivesText == null)
        {
            Debug.LogWarning("Lives text not initialized yet.");
            return;
        }

        gameLivesText.text = "Lives: " + lives;
    }

    private void OnApplicationQuit()
    {
        instance = null;
    }
}