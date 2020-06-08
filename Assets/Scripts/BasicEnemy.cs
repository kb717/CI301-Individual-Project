using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public Transform targetFood;
    public Transform target;
    private UnityEngine.AI.NavMeshAgent navComponent;
    RaycastHit hit;
    public float seeRange = 15f ;


    // Start is called before the first frame update
    void Start()
    {
        
        targetFood = GameObject.FindGameObjectWithTag("Food").transform;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        navComponent = this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();     //calls nav component aka navmesh etc

        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);                                //create new variables for the raycast to reference
        Vector3 origin = transform.position;

        if (Physics.Raycast(origin, forward, out hit, seeRange) && hit.collider.gameObject.tag == "Player")         //code to determine what object is in front of the AI
        {
            Follow();
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
                targetFood = this.gameObject.GetComponent<Transform>();             //if there is no food, find the transform of targetFood.
            }

            else
            {
                targetFood = GameObject.FindGameObjectWithTag("Food").transform;    //if cant find the transform, find the transform of any food, in case of a new one being spawned.           
            }

        }

        


    }



    void Follow()
    {

      
        if (target)
        {
            navComponent.SetDestination(target.position);                       //sets destination to be players current pos
        }

        else
        {
            if (target = null)
            {
                target = this.gameObject.GetComponent<Transform>();             //moves enemy towards player using transform
            }

            else
            {
                targetFood = GameObject.FindGameObjectWithTag("Food").transform;    //if it cant see player, change target the food instead
  
            }
        }

    }

}
