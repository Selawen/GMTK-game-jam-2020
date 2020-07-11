using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuButtons : MonoBehaviour
{
    private GameObject creditsPanel;
    bool creditsActive = false;
    public Button continueButton;

    // Start is called before the first frame update
    void Start()
    {
        creditsPanel = GameObject.Find("pnlCredits");
        creditsPanel.SetActive(false);

            if (PlayerPrefs.GetInt("LevelAchieved") >= 1)
            {
            continueButton.interactable = true;
            }
            else
            {
            continueButton.interactable = false;
            }
        }

    public void ToggleCredits()
    {
        creditsActive = !creditsActive;
        creditsPanel.SetActive(creditsActive);
    }

    public void LoadScene()
    {
        int savedLevel = PlayerPrefs.GetInt("LevelAchieved");
        SceneManager.LoadScene(savedLevel);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
