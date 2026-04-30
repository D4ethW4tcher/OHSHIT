using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public Food FileFood;
    public Snake FileSnake;
    public int extraGrowCount = 2;
    public string WinState = "Null";
    public void Powers()
    {
        if (FileFood.powertype == "Speed")
        {
            FileSnake.speed += 5;
        }
        if (FileFood.powertype == "Grow")
        {
            FileSnake.Grow();
        }
        if (FileFood.powertype == "Slow")
        {
            if (FileSnake.speed >= 10)
            {
                FileSnake.speed -= 5;
            }
        }
        if (FileFood.powertype == "win")
        {
            Debug.Log("you won");
            WinState = "Win";
        }
        if (FileFood.powertype == "ExtraGrow")
        {
            for (int i = 0; i < extraGrowCount; i++)
            {
                FileSnake.Grow();
            }
            extraGrowCount += 1;
        }
    }
}