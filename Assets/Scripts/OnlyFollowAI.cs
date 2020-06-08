using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyFollowAI : MonoBehaviour
{
    public Transform thisObject;
    public Transform target;
    private UnityEngine.AI.NavMeshAgent navComponent;

    // Start is called before the first frame update
    void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player").transform;                  
        navComponent = this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();     //calls nav component aka navmesh etc


    }

    // Update is called once per frame
    void Update()
    {   
        if (target)
        {
            navComponent.SetDestination(target.position);                       //sets destination to be players current pos
        }
    }
}
