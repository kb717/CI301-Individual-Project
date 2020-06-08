using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ClickSpawnScript : MonoBehaviour
{

    public GameObject Food;                                 //game object that the player spawns in.
    private Vector3 Point;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))                    //If left mouse button is pressed down run the function
        {
            SpawnFood();
        }
    }

    void SpawnFood()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);                //find camera position on where to spawn the game object the player wants to spawn it.

        if (Physics.Raycast(ray, out hit))
        {
            Point = hit.point;
            Instantiate(Food, Point, Quaternion.identity);                          //create a clone of the object by instatiating it with no rotation using quaternion.identity.
        }
    }
}

