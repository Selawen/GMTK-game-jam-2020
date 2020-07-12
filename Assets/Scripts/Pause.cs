using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private ChangeKey inputManager;
    private MenuManager menuManager;

    private bool isPaused;

    // Start is called before the first frame update
    void Awake()
    {
        inputManager = GameObject.Find("InputManager").GetComponent<ChangeKey>();
        menuManager = GameObject.Find("GUI").GetComponent<MenuManager>();
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(inputManager.pause))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        //pause gameplay when the game is paused and start it again when the game is resumed
        Time.timeScale = (isPaused ? 0 : 1);
        //lock cursor during gameplay, unlock when paused
        Cursor.lockState = (isPaused ? CursorLockMode.None : CursorLockMode.Locked);
        Cursor.visible = isPaused;

        //set pausemenu to active
        menuManager.TogglePauseMenu(isPaused);
    }
}
