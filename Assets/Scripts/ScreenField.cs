using UnityEngine;
using UnityEngine.UI;

public class ScreenField : MonoBehaviour
{
    private static ScreenField instance;

    public static ScreenField Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = new GameObject("ScreenField");
                instance = obj.AddComponent<ScreenField>();
                instance.Initialize();
            }
            return instance;
        }
    }

    private Image backgroundImage;

    public void Initialize()
    {
        Debug.Log("ScreenField initialized");

        // Create Canvas
        GameObject canvasObj = new GameObject("ScreenFieldCanvas");
        Canvas canvas = canvasObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        canvasObj.AddComponent<CanvasScaler>();
        canvasObj.AddComponent<GraphicRaycaster>();

        canvas.sortingOrder = 50;

        // Create background object
        GameObject bgObj = new GameObject("ScreenFieldBackground");
        bgObj.transform.SetParent(canvasObj.transform, false);

        backgroundImage = bgObj.AddComponent<Image>();

        // Full screen or custom rect (matching your old pixelInset style)
        RectTransform rect = backgroundImage.GetComponent<RectTransform>();

        rect.anchorMin = new Vector2(0, 0);
        rect.anchorMax = new Vector2(0, 0);

        rect.pivot = new Vector2(0, 0);

        // Equivalent of: Rect(22, 84, 980, 600)
        rect.anchoredPosition = new Vector2(22, 84);
        rect.sizeDelta = new Vector2(980, 600);

        // Set black color (replaces TextureHelper.Create1x1BlackTexture)
        backgroundImage.color = Color.black;
    }

    private void OnApplicationQuit()
    {
        instance = null;
    }
}