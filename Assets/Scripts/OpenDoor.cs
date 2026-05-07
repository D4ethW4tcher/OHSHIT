using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool door = false;
    public GameObject[] = Apples[];


    // Update is called once per frame
    void Update()
    {
        if (Apples[] == null)
        {
            Destroy(gameObject);
        }
    }
}
