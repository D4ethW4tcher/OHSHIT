using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool door = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        if (door == true)
        {
            gameObject.SetActive(false);
        }
    }
}
