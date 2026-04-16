using UnityEngine;

public class SnakeGame : MonoBehaviour
{
    private static SnakeGame instance;

    public static SnakeGame Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = new GameObject("SnakeGame");
                instance = obj.AddComponent<SnakeGame>();
                instance.Initialize();
            }
            return instance;
        }
    }

    public int gameScore;
    public int gameLives;
    public int scoreMultiplier = 100;

    public void Initialize()
    {
        Debug.Log("SnakeGame initialized");

        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        transform.localScale = Vector3.one;

        gameScore = 0;
        gameLives = 3;
        scoreMultiplier = 100;

        UpdateScore(0);
        UpdateLives(0);
    }

    public void UpdateScore(int additive)
    {
        gameScore += additive * scoreMultiplier;

        if (Score.Instance != null)
            Score.Instance.UpdateScoreText(gameScore);
    }

    public void UpdateLives(int additive)
    {
        gameLives += additive;

        // FIXED BUG: your original clamp did nothing useful
        gameLives = Mathf.Clamp(gameLives, 0, 999);

        if (Lives.Instance != null)
            Lives.Instance.UpdateLivesText(gameLives);
    }

    private void OnApplicationQuit()
    {
        instance = null;
    }
}