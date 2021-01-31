using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float timer = 15.0f;
    public int tokens = 3;
    bool isGameStarted = false;
    bool isGameWon;
    public ItemManager itemManager;
    public TextMeshProUGUI timerUI;
    public TextMeshProUGUI tokenUI;
    public clamp clamp;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void UpdateUI()
    {
        timerUI.text = timer.ToString("f2");
        tokenUI.text = tokens.ToString("D4");
    }
    public void GameStart()
    {
        itemManager.StartGame();
        isGameStarted = true;
        clamp.canMove = true;
    }
    void Update()
    {
        if (isGameStarted)
        {
            
            timer -= Time.deltaTime;
            UpdateUI();
            if(timer <= 0)
            {
                //Remove Token
                if(tokens > 0)
                {
                    tokens--;
                    timer = 15.0f;
                } else
                {
                    timer = 0.0f;
                    // Game Loss
                    // Show loss Screen
                }
            }
        } else
        {
            isGameStarted = false;
            clamp.canMove = false;
            // How to start game?

        }
    }

    public void NewRound(int num)
    {
        timer = 15.0f;
        tokens += num;
    }

    public void ResetGame()
    {
        timer = 15.0f;
        tokens = 3;
        itemManager.Reset(40);
        
    }
}
