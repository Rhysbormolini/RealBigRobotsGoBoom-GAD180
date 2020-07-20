using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject hudContainer, roundOverCanvas;
    
    public bool GamePlaying { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GamePlaying = false;

        BeginGame();
    }
    public void BeginGame()
    {
        GamePlaying = true;
        RoundCountdownController.instance.StartRound();
    }

    private void Update()
    {
        if (GamePlaying)
        {
            
        }
    }
   /* private void EndRound()
    {
        gamePlaying = false;
        Invoke("ShowRoundOverCanvas", 1.25f);
    }
    private void ShowRoundOverCanvas()
    {
        roundOverCanvas.SetActive(true);

    }
  */
}
