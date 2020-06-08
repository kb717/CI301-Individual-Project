using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class RunAwayAI : MonoBehaviour
{
    public float distanceAway = 8.0f;
    public float distanceToSpawn = 15.0f;
    public Transform thisObject;
    public Transform targetFood;
    public Transform target;
    private UnityEngine.AI.NavMeshAgent navComponent;
    RaycastHit hit;
    public Transform myPosition;
    public GameObject enemyToSpawn;
    private int seeRange = 30;

    


    // Start is called before the first frame update
    void Start()
    {

        targetFood = GameObject.FindGameObjectWithTag("Food").transform;                //this calls and sets all my variables created before the start function.
        target = GameObject.FindGameObjectWithTag("Player").transform;
        navComponent = this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();     //calls nav component aka navmesh etc
        myPosition = GameObject.Find("Scared_Enemy").transform;

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 forward = transform.TransformDirection(Vector3.forward);                //create new vectors for the raycast to reference
        Vector3 behind = -transform.TransformDirection(Vector3.forward);
        Vector3 origin = transform.position;

        if (Physics.Raycast(origin, forward, out hit, seeRange) && hit.collider.gameObject.tag == "Player")             //code to determine what object is in front of the AI
        {
            Flee();                                                                                                     //for example if a game object with the tag player is in front of the ai, run the flee function.
        }

        if (Physics.Raycast(origin, behind, out hit, seeRange) && hit.collider.gameObject.tag == "Player")             
        {
            Flee();
        }


        if (Physics.Raycast(origin, forward, out hit, seeRange) && hit.collider.gameObject.tag == "Food")
        {
            FollowFood();
        }


    }

    void FollowFood()
    {
        

        

        if (targetFood)
        {
            navComponent.SetDestination(targetFood.position);                       //sets destination to be food pos and move toward food
        }

        else 
        {
            if (targetFood = null)
            {
                targetFood = this.gameObject.GetComponent<Transform>();             //if there is no food, find the transform of targetFood
            }

            else
            {
                targetFood = GameObject.FindGameObjectWithTag("Food").transform;    //if cant find the transform, find the transform of any food, in case of a new one being spawned.
            }

        }


    }



    void Flee()
    {

        float dist = Vector3.Distance(target.position, transform.position);         //new float, finds the transform position of target, in this case the player.

        if (dist < distanceAway)                                                    //if distance from player is less than distance away
        {
            Vector3 disToPlayer = transform.position - target.position;             //another variable, location of current object minus location of player

            Vector3 newPos =  transform.position + disToPlayer ;                    //variable for the new position, current position plus disToPlayer vector. cannot use float
                                                                                    //together with vector
            navComponent.SetDestination(newPos);                                    //enemy will run towards the new position.
        }

        if (dist > distanceToSpawn && GameObject.Find("Herd_Enemy") == null)        //if the distance is greater than distance to spawn AND cant find any current herd enemies
        {
            UnityEngine.Debug.Log("Spawned Enemies");

            SpawnEnemies();                                                         //runs spawn enemies function
        }

    }

    void SpawnEnemies()
    {
        Instantiate(enemyToSpawn, transform.position, Quaternion.identity);         //spawns new enemy on top of the old one
        Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        

        Destroy(gameObject);                                                        //destroys the current game object at the end of the function. stops from spawning a lot of enemies.
    }

}
