using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public Food FileFood;
    public Snake FileSnake;
    public void Powers()
    {
        if (FileFood.powertype == "Speed")
        {
            FileSnake.speed += 5;
        }
        if (FileFood.powertype == "Grow")
        {
            Grow();
        }
        if (FIleFood.powertype == "Slow")
        {
            if (FileSnake.speed >= 10)
            {
                FileSnake.speed -= 5;
            }
        }
        if (FileFood.powertype == "win")
        {
            Debug.Log("you won");
        }
    }
}