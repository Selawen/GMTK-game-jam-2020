using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject howToPlayPanel;

    bool howToPlayActive;
    bool pauseMenuActive;

    // Start is called before the first frame update
    void Awake()
    {
        howToPlayActive = true;
        ToggleHowToPlay();

        TogglePauseMenu(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("LoadingScene");
    }

    public void ToggleHowToPlay()
    {
        howToPlayActive = !howToPlayActive;
        howToPlayPanel.SetActive(howToPlayActive);
    }

    public void TogglePauseMenu(bool pauseMenuActive)
    {
        pausePanel.SetActive(pauseMenuActive);
    }
}
