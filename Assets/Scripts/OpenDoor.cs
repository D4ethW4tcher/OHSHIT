using UnityEngine;
using System.Collections.Generic;

public class OpenDoor : MonoBehaviour
{
    public bool door = false;
    public List<Food> Apples = new List<Food>();

    void Update()
    {
        if (Apples.Count == 0)
        {
            Debug.Log("Apples are gone");
            Destroy(gameObject);
        }
    }

    public void RemoveApple(Food apple)
    {
        Apples.Remove(apple);
    }
}