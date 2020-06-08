using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSMBase : StateMachineBehaviour                                                           //this class derives from statemachine behaviour, which is used by the animator
{
    public GameObject Enemy;
    public GameObject Player;
    public GameObject Food;
    public float accToWP = 2.0f;
    public UnityEngine.AI.NavMeshAgent agent;                                                               //setting all the variables here so other classes can extend from here

    // Start is called before the first frame update
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)       //setting all variables as soon as the state is entered, which is usually at the start of the game
    {
        Enemy = animator.gameObject;
        Player = Enemy.GetComponent<EnemyAI>().GetPlayer();
        Food = Enemy.GetComponent<EnemyAI>().GetFood();
        agent = Enemy.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
