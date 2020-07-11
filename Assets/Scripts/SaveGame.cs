using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SaveGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Save()
    {
        PlayerPrefs.SetInt("LevelAchieved", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
    }
}
