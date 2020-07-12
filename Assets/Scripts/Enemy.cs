using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float radius = 6;

    private Animator animator;

    public int changedControl;


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,radius);
    }

    public enum State
    {
        Idle,
        Roaming,
        ChasingTarget,
        Shooting

    }

     public State currentState;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = gameObject.GetComponent<Animator>();
        currentState = State.Roaming;

    }

    private void Update()
    {

        if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= radius && currentState!= State.Shooting)
        {
            currentState = State.ChasingTarget;
            SwitchState();
        }
        else if(currentState != State.Shooting)
        {
            currentState = State.Roaming;
            SwitchState();
        }
    }


    public void SwitchState()
    {
        switch (currentState)
        {
            case State.Idle:
                animator.SetBool("isChasing", false);
                animator.SetBool("isPatroling", false);
                animator.SetBool("isShooting", false);

                break;
            case State.Roaming:
                animator.SetBool("isChasing", false);
                animator.SetBool("isPatroling", true);
                animator.SetBool("isShooting", false);

                break;
            case State.ChasingTarget:
                animator.SetBool("isChasing", true);
                animator.SetBool("isPatroling", false);
                animator.SetBool("isShooting", false);

                break;
            case State.Shooting:
                animator.SetBool("isChasing", false);
                animator.SetBool("isPatroling", false);
                animator.SetBool("isShooting", true);

                break;
            default:
                break;
        }
    }

    public void GotToShooting()
    {
        currentState = State.Shooting;
    }

    public void GotToRoaming()
    {
        currentState = State.Roaming;
    }

}
