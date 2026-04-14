using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using CodeMonkey;

public class FoodManager : MonoBehaviour
{
    private Vector2Int foodGridPosition;
    private int width;
    private int height;
    public FoodManager(int width, int height){
        this.width = width;
        this.height = height;

        //SpawnFood();

        InvokeRepeating(nameof(SpawnFood), 1f, 1f);
    }
    private void SpawnFood() {
        foodGridPosition = new Vector2Int(Random.Range(0, width), Random.Range(0, height));
        GameObject foodGameObject = new GameObject("Food", typeof(SpriteRenderer));
        foodGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.i.foodSprite;
        foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y);
    }
    public bool TrySnakeEatFood(Vector2Int snakeGridPosition){
        if (snakeGridPosition == foodGridPosition) {
            object.Destroy(foodGameObject);
            return true;
        }
        else {
            return false;
        }
    }
}
