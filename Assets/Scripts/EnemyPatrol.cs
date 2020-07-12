using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : StateMachineBehaviour
{
    public Transform playerPos;
    private NavMeshAgent meshAgent;

    private Vector3 startingPos;
    private Vector3 roamPosition;
    private float timeToSearchNewSpot = 1f;

    private Vector3 GetRoamingPosition()
    {
        return startingPos + GetRandomDir() * Random.Range(1f, 5f);
    }
    public Vector3 GetRandomDir()
    {
        return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        startingPos = animator.transform.position;
        roamPosition = GetRoamingPosition();

        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        meshAgent = animator.GetComponent<NavMeshAgent>();

    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        meshAgent.SetDestination(roamPosition);

        timeToSearchNewSpot -= 10 * Time.deltaTime;
        //Debug.Log("nani? " + timeToSearchNewSpot);


        if (timeToSearchNewSpot <= 0)
        {
            //Debug.Log("nani whats over there? " + timeToSearchNewSpot);
            timeToSearchNewSpot = Random.Range(13f, 15f);
            roamPosition = GetRoamingPosition();

        }

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
