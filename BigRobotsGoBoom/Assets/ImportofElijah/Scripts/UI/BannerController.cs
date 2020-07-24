using UnityEngine;
using System.Collections;

public class BannerController : MonoBehaviour {

	private Animator animator;
	private AudioSource audioPlayer;

	private bool animating;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		audioPlayer = GetComponent<AudioSource> ();
	
	}

	public void showRoundFight(){
		animating = true;
		//animator.SetTrigger ("Show_Round_Fight");
	}

	public void showYouWin(){
		animating = true;
		animator.SetTrigger ("Show_You_Win");
	}

	public void showYouLose(){
		animating = true;
		animator.SetTrigger ("Show_You_Lose");
	}

	public void playVoice(AudioClip voice){
		GameUtils.playSound (voice, audioPlayer);
	}

	public void animationEnded(){
		animating = false;
	}

	public bool isAnimating{
		get{
			return animating;
		}
	}
}
