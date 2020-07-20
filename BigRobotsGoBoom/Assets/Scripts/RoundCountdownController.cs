using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundCountdownController : MonoBehaviour
{
    public static RoundCountdownController instance;

    public int timeLeft = 99;
    public GameObject timerText;
    public bool TimerIsActive { get; private set; }
    public GameObject RoundOverCanvas;

    public void Awake()
    {
        instance = this;
        timerText.gameObject.SetActive(false);
    }
    public void Start()
    {
       // StartRound();
    }
    
    public void StartRound()
    {

        TimerIsActive = true;
        StartCoroutine(TimerTake());
        timerText.gameObject.SetActive(true);
    }
  
   public void Update()
   {
       if (TimerIsActive == false && timeLeft > 0)
       {
           //   StartCoroutine(TimerTake());
           //   timerText.gameObject.SetActive(true);
       }
   }   
   
    IEnumerator TimerTake()
    {
        yield return new WaitForSeconds(5f);
        while (timeLeft > 0)
        {
            timerText.GetComponent<Text>().text  = timeLeft.ToString();
            

            yield return new WaitForSeconds(1f);
            timeLeft --;
           /* if (timeLeft < 10)
            {
                timerText.GetComponent<Text>().text = "00:0" + timeLeft;
            }
            else
            {
                timerText.GetComponent<Text>().text = "00:" + timeLeft;
            }*/
        }

        yield return new WaitForSeconds(1f);
        //TimerIsActive = false;
        
        timerText.gameObject.SetActive(false);

        RoundOverCanvas.gameObject.SetActive(true);

    }
}

