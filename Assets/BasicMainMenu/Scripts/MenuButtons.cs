using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class MenuButtons : MonoBehaviour
{
    private GameObject creditsPanel;
    bool creditsActive = false;
    public Button continueButton;

    // Start is called before the first frame update
    void Awake()
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
            continueButton.GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
            }
        }

    public void ToggleCredits()
    {
        creditsActive = !creditsActive;
        creditsPanel.SetActive(creditsActive);
    }

    public void LoadScene()
    {
        Time.timeScale = 1;
        int savedLevel = PlayerPrefs.GetInt("LevelAchieved");
        SceneManager.LoadScene(savedLevel);
    }

    public void NewGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("tries", 0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
