using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using CodeMonkey;
//using CodeMonkey.Utils;

public class GameHandler : MonoBehaviour {
    private  FoodManager levelGrid;
    private void Start() {
        Debug.Log("GameHandler.Start");
        levelGrid = new FoodManager(20,20);
    }
}
