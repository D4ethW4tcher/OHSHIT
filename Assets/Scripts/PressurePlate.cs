using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool isPressed = false;

    private void OnTriggerEnter(Collider other)
    {
        isPressed = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isPressed = false;
    }
}