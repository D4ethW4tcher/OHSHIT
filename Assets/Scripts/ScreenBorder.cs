using UnityEngine;
using UnityEngine.UI;

public class ScreenBorder : MonoBehaviour
{
    private static ScreenBorder instance;

    public static ScreenBorder Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = new GameObject("ScreenBorder");
                instance = obj.AddComponent<ScreenBorder>();
                instance.Initialize();
            }
            return instance;
        }
    }

    private Image borderImage;

    public void Initialize()
    {
        Debug.Log("ScreenBorder initialized");

        // Create Canvas
        GameObject canvasObj = new GameObject("BorderCanvas");
        Canvas canvas = canvasObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        canvasObj.AddComponent<CanvasScaler>();
        canvasObj.AddComponent<GraphicRaycaster>();

        canvas.sortingOrder = 10;

        // Create border object
        GameObject borderObj = new GameObject("ScreenBorderImage");
        borderObj.transform.SetParent(canvasObj.transform, false);

        borderImage = borderObj.AddComponent<Image>();

        // Full-screen layout (equivalent to pixelInset full screen)
        RectTransform rect = borderImage.GetComponent<RectTransform>();

        rect.anchorMin = new Vector2(0, 0);
        rect.anchorMax = new Vector2(1, 1);

        rect.offsetMin = Vector2.zero;
        rect.offsetMax = Vector2.zero;

        // Set gray color (replaces TextureHelper.Create1x1Texture(Color.gray))
        borderImage.color = Color.gray;
    }

    private void OnApplicationQuit()
    {
        instance = null;
    }
}