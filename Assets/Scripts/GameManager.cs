using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] public int playerRemaining;
    [SerializeField] public int enemyRemaining;
    [SerializeField] private TextMeshProUGUI playerRemainingText;
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private TextMeshProUGUI gameMessage;
    
    public bool gameHasEnded = false;

    private void Start()
    {
        nextLevelButton.gameObject.SetActive(false);
        gameMessage.text = "";
    }

    void Update()
    {
        playerRemainingText.text = "Player Remaining: " + playerRemaining;

        if (enemyRemaining == 0)
        {
            gameHasEnded = true;
            gameMessage.text = "You Win!\n Press Next Level to Continue";
            nextLevelButton.gameObject.SetActive(true);
        }
        
        if (playerRemaining == 0)
        {
            gameMessage.text = "You Lose!\n Press Restart or go back to Main Menu";
            gameHasEnded = true;
        }
    }
}
