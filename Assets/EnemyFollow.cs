using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public GameObject playerPos;
    private NavMeshAgent curr;

    // Start is called before the first frame update
    void Start()
    {
        curr = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        curr.SetDestination(playerPos.transform.position);
    }
}
