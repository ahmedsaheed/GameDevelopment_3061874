using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUIScript : MonoBehaviour
{
    public GameManager gameManager;
    public TMP_Text scoreText;
    public TMP_Text healthText;

    private void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    
    private void Update() {
        scoreText.text = "Score: " + gameManager.playerScore;
        healthText.text = "Health: " + gameManager.playerHealth;
    }
}
