using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    private Vector2Int gridMoveDirection;
    private Vector2Int gridPosition;
    private float GridMoveTimer;
    private float GridMoveTimerMax;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake(){
        gridPosition = new Vector2Int(10, 10);
        GridMoveTimerMax = .5f;
        GridMoveTimer = GridMoveTimerMax;
        gridMoveDirection = new Vector2Int(1,0);
    }
    private void Update()
    {
        HandleInput();
        HandleGridMovement();
        
    }
    private void HandleInput(){
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            if (gridMoveDirection.y != -1) {
                gridMoveDirection.y = +1;
                gridMoveDirection.x = 0;
            }
        }        
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            if (gridMoveDirection.y != 1) {
                gridMoveDirection.y = -1;
                gridMoveDirection.x = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            if (gridMoveDirection.x != -1) {
                gridMoveDirection.y = 0;
                gridMoveDirection.x = +1;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (gridMoveDirection.x != 1) {
                gridMoveDirection.y = 0;
                gridMoveDirection.x = -1;
            }
        }
    }
    private void HandleGridMovement(){
        GridMoveTimer += Time.deltaTime;
        if (GridMoveTimer >= GridMoveTimerMax){
            gridPosition += gridMoveDirection;
            gridMoveTimer -= GridMoveTimerMax;

            transform.position = new Vector3(gridPosition.x,gridPosition.y);
            transform.eulerAngles = new Vector3 =(0,0,GetAngleFromVector(gridMoveDirection) -90);
        }
        
    }
    private flaot GetAngleFromVector(Vector2Int dir) {
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }
}
