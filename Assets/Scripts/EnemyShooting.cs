using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : StateMachineBehaviour
{
    private float timer;
    public GameObject player;
    public GameObject thisEnemy;
    private Vector3 shootDirection;
    public GameObject eventSystem;
    private int shots;
    

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        eventSystem = GameObject.Find("EventSystem");
        player = GameObject.Find("Player");
        shots = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        thisEnemy = animator.gameObject;
        thisEnemy.transform.LookAt(player.transform, Vector3.up);


        timer -= Time.deltaTime;

        if (timer <= 0.1f)
        {
            shootDirection = thisEnemy.transform.forward * 10;
            //Gizmos.color = Color.red;
            //Vector3 lazerBeam = (animator.gameObject.transform.position + player.transform.position);
            //Gizmos.DrawLine((animator.gameObject.transform.position + new Vector3(0,1.688f,0)), player.transform.position);
        }

        if (timer <= 0)
        {
            Shoot();
            timer = 0.5f;
            shots++;
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

    void Shoot()
    {
        RaycastHit thisShot;
        Ray shootRay = new Ray(thisEnemy.transform.position, shootDirection);
        
        if (player.GetComponent<Collider>().Raycast(shootRay, out thisShot, 10))
        {
            if (thisEnemy.GetComponent<Enemy>().changedControl <= 4)
            {
                player.GetComponent<Movement>().ShotModifier(thisEnemy.GetComponent<Enemy>().changedControl);
            } else if (thisEnemy.GetComponent<Enemy>().changedControl == 5)
            {
                eventSystem.GetComponent<Pause>().TogglePause();
            }
        }

    }
}
