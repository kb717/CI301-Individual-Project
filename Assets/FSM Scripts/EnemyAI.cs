using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Animator animator;                                  //setting variables
    public GameObject player;
    public GameObject food;
    public GameObject GetPlayer()                       //grab the game object for player and food and return the player and food
    {
        return player;
    }

    public GameObject GetFood()
    {
        return food;
    }

    // Start is called before the first frame update
    void Start()                                            
    {
        player = GameObject.FindGameObjectWithTag("Player");        //set the objects upon start so i dont have to do it manually
        food = GameObject.FindGameObjectWithTag("Food");
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("distFromPlayer", Vector3.Distance(transform.position, player.transform.position));       //changes the float in the animator for food and player, checks how far away they are
        food = GameObject.FindGameObjectWithTag("Food");                                                            //constantly checks if food is on the map as its in update
        animator.SetFloat("distFromFood", Vector3.Distance(transform.position, player.transform.position));         

    }
}
