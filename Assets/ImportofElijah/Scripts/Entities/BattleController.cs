using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BattleController : MonoBehaviour
{
	public int roundTime = 100;
	private float lastTimeUpdate = 0;
	private bool battleStarted;
	private bool battleEnded;

    public float timeLeft = 10.0f; // set game time

    public FighterPaladin player1;
	public FighterSting player2;
	public BannerController banner;
	public AudioSource musicPlayer;
	public AudioClip backgroundMusic;

	// Use this for initialization
	void Start ()
    {
		//banner.showRoundFight ();
	}

	/*private void expireTime(){
		if (player1.healthPercent > player2.healthPercent) {
			player2.health = 0;
		} else {
			player1.health = 0;
		}
	}*/
	
	// Update is called once per frame
	void Update ()
    {
		/*if (!battleStarted && !banner.isAnimating)
        {
			battleStarted = true;

			player1.enable = true;
			player2.enable = true;

			GameUtils.playSound(backgroundMusic, musicPlayer);
		}*/

        //if (battleStarted && !battleEnded) 
       
			if (roundTime > 0 && Time.time - lastTimeUpdate > 1)
            {
				roundTime--;
				lastTimeUpdate = Time.time;
                
				if (roundTime == 0){
					GameOver();
				}
			}
		
    }

    

       
        void GameOver()
        {
            SceneManager.LoadScene(0); // reset to menu
        }
}
