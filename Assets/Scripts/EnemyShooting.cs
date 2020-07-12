using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyShooting : StateMachineBehaviour
{
    private float timer;
    public GameObject player;
    public GameObject thisEnemy;
    private Vector3 shootDirection;
    public GameObject eventSystem;

    public AudioSource audioSource;
    public AudioClip audioClip;

    private NavMeshAgent meshAgent;

    public int shots;
    

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        thisEnemy = animator.gameObject;

        meshAgent = animator.GetComponent<NavMeshAgent>();
        eventSystem = GameObject.Find("EventSystem");
        player = GameObject.Find("Player");
        shots = 0;
        audioSource = animator.GetComponent<AudioSource>();
        timer = 2;
        meshAgent.SetDestination(thisEnemy.transform.position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        thisEnemy = animator.gameObject;
        thisEnemy.transform.LookAt((player.transform), Vector3.up);

        if (Vector3.Distance(thisEnemy.transform.position, player.transform.position) >= 4.0f)
        {
            GameObject.Find("InputManager").GetComponent<ChangeKey>().alreadyChanged = false;
            meshAgent.SetDestination(thisEnemy.transform.position);
            if (shots >= 5)
            {
                thisEnemy.GetComponent<Enemy>().GotToRoaming();
            }

            timer -= Time.deltaTime;

            if (timer <= 0.05f)
            {
                shootDirection = thisEnemy.transform.forward * 10;
                //Gizmos.color = Color.red;
                //Vector3 lazerBeam = (animator.gameObject.transform.position + player.transform.position);
                //Gizmos.DrawLine((animator.gameObject.transform.position + new Vector3(0,1.688f,0)), player.transform.position);
            }

            if (timer <= 0)
            {
                Shoot();
                timer = 2;
                shots++;
            }
        }
        else if(Vector3.Distance(thisEnemy.transform.position, player.transform.position) < 4.0f)
        {
            GameObject.Find("InputManager").GetComponent<ChangeKey>().alreadyChanged = false;
            meshAgent.SetDestination(thisEnemy.transform.forward*-1);
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
        audioSource.PlayOneShot(audioClip);

        if (player.GetComponent<Collider>().Raycast(shootRay, out thisShot, 15))
        {
            int controlChanged = thisEnemy.GetComponent<Enemy>().changedControl;
            Debug.Log(controlChanged);
            if (controlChanged <= 4)
            {
                player.GetComponent<Movement>().ShotModifier(controlChanged);
                Debug.Log(controlChanged);
            } else if (controlChanged == 5)
            {
                eventSystem.GetComponent<Pause>().TogglePause();
            }
        }

    }
}
