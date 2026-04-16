using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenDeath : MonoBehaviour
{
    private static ScreenDeath instance;

    public static ScreenDeath Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = new GameObject("ScreenDeath");
                instance = obj.AddComponent<ScreenDeath>();
                instance.Initialize();
            }
            return instance;
        }
    }

    private Image deathScreenImage;

    private Color deathColor;
    private Color invisColor;

    public void Initialize()
    {
        Debug.Log("ScreenDeath initialized");

        // Create Canvas
        GameObject canvasObj = new GameObject("DeathCanvas");
        Canvas canvas = canvasObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        canvasObj.AddComponent<CanvasScaler>();
        canvasObj.AddComponent<GraphicRaycaster>();

        canvas.sortingOrder = 200; // ensure it renders on top

        // Create full-screen Image
        GameObject imgObj = new GameObject("DeathScreen");
        imgObj.transform.SetParent(canvasObj.transform, false);

        deathScreenImage = imgObj.AddComponent<Image>();

        // Full screen stretch
        RectTransform rect = deathScreenImage.GetComponent<RectTransform>();
        rect.anchorMin = Vector2.zero;
        rect.anchorMax = Vector2.one;
        rect.offsetMin = Vector2.zero;
        rect.offsetMax = Vector2.zero;

        // Color setup
        deathColor = new Color(1f, 0f, 0f, 0.3f);   // red semi-transparent
        invisColor = new Color(1f, 0f, 0f, 0f);     // invisible

        deathScreenImage.color = invisColor;
    }

    public IEnumerator FlashDeathScreen()
    {
        if (deathScreenImage == null)
            yield break;

        for (int i = 0; i < 4; i++)
        {
            deathScreenImage.color = deathColor;
            yield return new WaitForSeconds(0.1f);

            deathScreenImage.color = invisColor;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void OnApplicationQuit()
    {
        instance = null;
    }
}