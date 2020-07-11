using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private ChangeKey inputManager;

    private void Start()
    {
        inputManager = GameObject.Find("InputManager").GetComponent<ChangeKey>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            inputManager.RandomKey();

        }
    }
}
