using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float radius = 6;

    private Animator animator;

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

     public State currenState;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        currenState = State.Roaming;

    }

    private void FixedUpdate()
    {

        if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= radius)
        {
            Debug.Log("AHA!!!");
            currenState = State.ChasingTarget;
        }
        else
        {
            Debug.Log("Nvm");
            currenState = State.Roaming;
        }
        Debug.Log("AHA!!!");


        switch (currenState)
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

}
