using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    //Variables
    public bool isPressed = false;

    //Functions
     
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnTriggerEnter (isPressed = true;)

        OnTriggerExit (isPressed = false;)
    }
}
