﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    private GameObject gameOverPanel;
    private GameObject player;
    public TextMeshProUGUI triesText;

    // Start is called before the first frame update
    void Awake()
    {
        gameOverPanel = GameObject.Find("pnlGameOver");
        //triesText = GameObject.Find("pnlGameOver").GetComponentInChildren<TextMeshProUGUI>();

        gameOverPanel.SetActive(false);
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {
            if (player.transform.position.y <= -1)
            {
                GameIsOver();
            }
        }
    }

    public void GameIsOver()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);

        int tries = PlayerPrefs.GetInt("tries");
        tries++;
        PlayerPrefs.SetInt("tries", tries);

        triesText.text = "lost control <b>" + tries + "</b> times";
    }
}
