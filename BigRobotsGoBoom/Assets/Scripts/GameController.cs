using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public Text timeCounter;
    public bool gamePlaying { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        gamePlaying = false;

        BeginGame();
    }
    public void BeginGame()
    {
        gamePlaying = true;
       
    }

    private void Update()
    {
     
    }
}
