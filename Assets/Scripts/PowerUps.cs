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
    }
}