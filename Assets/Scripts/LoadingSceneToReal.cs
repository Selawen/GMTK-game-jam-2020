using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneToReal : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1;
        int savedLevel = PlayerPrefs.GetInt("LevelAchieved");
        SceneManager.LoadScene(savedLevel);
    }

}
