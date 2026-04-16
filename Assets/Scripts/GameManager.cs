using UnityEngine;
using System.Collections;

/// <summary>
/// Stores game state and game information
/// </summary>
public class GameManager : MonoBehaviour
{
    void Start () 
    {
        ScreenBorder.Instance.Initialize();
        ScreenField.Instance.Initialize();
        Score.Instance.Initialize();
        Lives.Instance.Initialize();
        SnakeGame.Instance.Initialize();
        Food.Instance.Initialize();
        Snake.Instance.Initialize();
        ScreenDeath.Instance.Initialize();
    }
}