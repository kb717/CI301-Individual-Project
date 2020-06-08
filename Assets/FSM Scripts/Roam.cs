using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Roam : EnemyFSMBase
{
    GameObject[] waypoints;                     //declares an array list for waypoints with []
    int currentWaypoint;                        //integer for current waypoint


    void Awake()
    {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");          //on awake so when game starts, fills the waypoints array list with objects
    }                                                                       //labelled waypoints

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);                                                     //upon entering state, grab the animator, stateInfo and the index of my layers
        currentWaypoint = 0;                                                                                    //current waypoint set to zero
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (waypoints.Length == 0)                                                                                  //if the waypoints equal to 0, returns the value
            return;
        if(Vector3.Distance(waypoints[currentWaypoint].transform.position,Enemy.transform.position) < accToWP)
        {
            currentWaypoint++;                                                                                      //for every waypoints travelled to, increase the waypoints by 1
            if(currentWaypoint >= waypoints.Length)                                                                 //which makes it travel to the next one
            {
                currentWaypoint = 0;                                                                                //if the the current waypoint is greater than or equals to the length of the array list
            }                                                                                                       //set the next waypoint to 0
        }

        agent.SetDestination(waypoints[currentWaypoint].transform.position);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
