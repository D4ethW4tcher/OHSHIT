using UnityEngine;
using System.Collections.Generic;

public class OpenDoor : MonoBehaviour
{
    public List<GameObject> Apples = new List<GameObject>();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Apples.Count == 0)
        {
            Destroy(gameObject);
        }
    }
}