﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HudController : MonoBehaviour {
	public Fighter player1;
	public Fighter player2;

	public Text player1Tag;
	public Text player2Tag;

	public Scrollbar leftBar;
	public Scrollbar rightBar;

	public Text timerText;
    //public float timer;

	public BattleController battle;


	// Use this for initialization
	void Start () {
		player1Tag.text = player1.fighterName;
		player2Tag.text = player2.fighterName;
	}
	
	// Update is called once per frame
	void Update () {
		timerText.text = battle.roundTime.ToString();

		if (leftBar.size > player1.healthPercent) {
			leftBar.size-= 0.01f;
		}
		if (rightBar.size > player2.healthPercent) {
			rightBar.size-= 0.01f;
		}
	

    
    /*
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = 0;
            //You can restart the scene here
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        */
        
    }
}
