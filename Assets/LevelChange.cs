using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Time.timeScale = 1;
            int savedLevel = PlayerPrefs.GetInt("LevelAchieved");
            SceneManager.LoadScene(savedLevel +1);
        }
    }
}
