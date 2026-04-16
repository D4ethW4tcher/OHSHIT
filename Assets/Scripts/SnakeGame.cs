using UnityEngine;
using System.Collections;

public class SnakeGame : MonoBehaviour
{
    private static SnakeGame instance = null;

    public int gameScore = 0;
    public int gameLives = 3;
    public int scoreMultipler = 100;

    public static SnakeGame Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("SnakeGame").AddComponent<SnakeGame>();
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
        print("Snake Game Instance destroyed");
        instance = null;
    }

    public void UpdateScore(int additive)
    {
        gameScore += additive * scoreMultipler;
        Score.Instance.UpdateScoreText(gameScore.ToString());
    }

    public void UpdateLives(int additive)
    {
        gameLives += additive;
        gameLives = Mathf.Clamp(gameLives, 0, gameLives);
        Lives.Instance.UpdateLivesText(gameLives.ToString());
    }

    public void Initialize()
    {
        print("SnakeGame initialized");
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        transform.localScale = Vector3.one;

        gameScore = 0;
        gameLives = 3;
        scoreMultipler = 100;
        UpdateScore(0);
        UpdateLives(0);
    }
}