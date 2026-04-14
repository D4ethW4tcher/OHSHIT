using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    private Vector2Int gridMoveDirection;
    private Vector2Int gridPosition;
    private float GridMoveTimer;
    private float GridMoveTimerMax;
    private int  snakeBodySize;
    private List<Vector2Int> snakeMovePositionList;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake(){
        gridPosition = new Vector2Int(10, 10);
        GridMoveTimerMax = .5f;
        GridMoveTimer = GridMoveTimerMax;
        gridMoveDirection = new Vector2Int(1,0);

        snakeMovePositionList = new List<Vector2Int>();
        snakeBodySize = 0;
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
            GridMoveTimer -= GridMoveTimerMax;

            snakeMovePositionList.Insert(0, gridPosition);
            gridPosition+= gridMoveDirection;

            bool snakeAteFood = FoodManager.TrySnakeEatFood(gridPosition);
            if (snakeAteFood){
                //Snake ate food, grow body.
                snakeBodySize++;
            }

            if (snakeMovePositionList.Count >= snakeBodySize + 1) {
                snakeMovePositionList.RemoveAt(snakeMovePositionList.Count - 1);
            }

            for (int i = 0; i < snakeMovePositionList.Count; i++){
                Vector2Int SnkaeMovePosition = snakeMovePositionList[i];
                World_Sprite worldSprite = World_Sprite.Create(new Vector3(snakeMovePosition.x, snakeMovePosition.y), Vector3.one * .5f, Color.white);
                FunctionTimer.Create(worldSprite.DestroySelf, gridMoveTimerMax);
            }

            transform.position = new Vector3(gridPosition.x,gridPosition.y);
            transform.eulerAngles = new Vector3(0,0,GetAngleFromVector(gridMoveDirection) -90);

        }
        
    }
    private float GetAngleFromVector(Vector2Int dir) {
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }
}
