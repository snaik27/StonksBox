using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timer = 15.0f;
    public int tokens = 3;
    bool isGameStarted = false;
    bool isGameWon;
    // Start is called before the first frame update
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        if (isGameStarted)
        {
            timer -= Time.deltaTime;

            if(timer <= 0)
            {
                if (isGameWon)
                {
                    //Game Win
                }
                else
                {
                    //Game Loss
                }
            }
        }
    }
}
