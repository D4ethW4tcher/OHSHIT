using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public gameObject PressurePlates;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PressurePlates = (PressurePlate)FindObjectOfType(typeof(PressurePlate));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
