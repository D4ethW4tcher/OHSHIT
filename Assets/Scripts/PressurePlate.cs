using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    //Variables
    public bool isPressed = false;

    //Functions
    private void OnTriggerEnter {
        isPressed = true;
    }
    private void OnTriggerExit {
        isPressed = false;
    }  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
