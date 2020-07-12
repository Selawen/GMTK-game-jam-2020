using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private ChangeKey inputManager;
    private GameOver loseControl;

    private void Start()
    {
        inputManager = GameObject.Find("InputManager").GetComponent<ChangeKey>();
        loseControl = GameObject.Find("EventSystem").GetComponent<GameOver>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().changedControl = inputManager.RandomKey();
            other.gameObject.GetComponent<Enemy>().GotToShooting();
        }

        if (other.CompareTag("Hazard"))
        {
            loseControl.GameIsOver();
        }
    }
}
