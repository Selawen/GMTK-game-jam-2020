using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    public int sceneNumber;

    public void SwitchSceneTo(int _sceneNumber)
    {
        SceneManager.LoadScene(_sceneNumber);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SwitchSceneTo(sceneNumber);
        }
    }
}
