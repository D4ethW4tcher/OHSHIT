using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    private Vector2Int gridPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake(){
        gridPosition = new Vector2Int(10, 10);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            gridPosition.y += 1;
        }
        transform.position = new Vector3(gridPosition.x,gridPosition.y);
    }
}
