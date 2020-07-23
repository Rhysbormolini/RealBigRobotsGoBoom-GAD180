using UnityEngine;
using System.Collections;

public class Fighter : MonoBehaviour {
	public enum PlayerType
	{
		HUMAN, AI	
	};

	public static float MAX_HEALTH = 100f;

	public float healt = MAX_HEALTH;
	public string fighterName;
	public Fighter oponent;
	public bool enable;

	public PlayerType player;
	public FighterStates currentState = FighterStates.Idle;

	protected Animator animator;
	private Rigidbody myBody;
	private AudioSource audioPlayer;

	//for AI only
	private float random;
	private float randomSetTime;
	
	// Use this for initialization
	void Start () {
		myBody = GetComponent<Rigidbody> ();
		animator = GetComponent<Animator> ();
		audioPlayer = GetComponent<AudioSource> ();
	}

	public void UpdateHumanInput (){
		if (Input.GetAxis ("Horizontal") > 0.1) {
			animator.SetBool ("Walk Forward", true);
		} else {
			animator.SetBool ("Walk Forward", false);
		}

		if (Input.GetAxis ("Horizontal") < -0.1) {
			if (oponent.attacking){
				animator.SetBool ("Walk Forward", false); //backward
				//animator.SetBool ("Block", true);
			}else{
				animator.SetBool ("Walk Forward", true); //backward
				//animator.SetBool ("Block", false);
			}
		} else {
			animator.SetBool ("Walk Forward", false); //backward
			//animator.SetBool ("Block", false);
		}

        /*
		if (Input.GetAxis ("Vertical") < -0.1) {
			animator.SetBool ("DUCK", true);
		} else {
			animator.SetBool ("DUCK", false);
		}
        */

		if (Input.GetKeyDown (KeyCode.W)) {
			animator.SetTrigger("Jump");
		} 

		if (Input.GetKeyDown (KeyCode.V)) {
			animator.SetTrigger("Hit Sword");
		}

		if (Input.GetKeyDown (KeyCode.B)) {
			animator.SetTrigger("Hit Gun");
		}

	}

	public void UpdateAiInput (){
		animator.SetBool ("defending", defending);
		//animator.SetBool ("invulnerable", invulnerable);
		//animator.SetBool ("enable", enable);

		animator.SetBool ("oponent_attacking", oponent.attacking);
		animator.SetFloat ("distanceToOponent", getDistanceToOponennt());

		if (Time.time - randomSetTime > 1) {
			random = Random.value;
			randomSetTime = Time.time;
		}
		animator.SetFloat ("random", random);
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetFloat ("health", healtPercent);

		if (oponent != null) {
			animator.SetFloat ("oponent_health", oponent.healtPercent);
		} else {
			animator.SetFloat ("oponent_health", 1);
		}

		if (enable) {
			if (player == PlayerType.HUMAN) {
				UpdateHumanInput ();
			}else{
				UpdateAiInput();
			}

		}

		if (healt <= 0 && currentState != FighterStates.Death) {
			animator.SetTrigger ("Death");
		}
	}

	private float getDistanceToOponennt(){
		return Mathf.Abs(transform.position.x - oponent.transform.position.x);
	}

	public virtual void hurt(float damage){
		if (!invulnerable) {
			if (defending){
				damage *= 0.2f;
			}
			if (healt >= damage) {
				healt -= damage;
			} else {
				healt = 0;
			}

			if (healt > 0) {
				animator.SetTrigger ("Take_Hit");
			}
		}
	}

	public void playSound(AudioClip sound){
		GameUtils.playSound (sound, audioPlayer);
	}

	public bool invulnerable {
		get {
			return currentState == FighterStates.Take_Hit 
				|| currentState == FighterStates.Take_Hit_Defend
					|| currentState == FighterStates.Death;
		}
	}

	public bool defending {
		get {
			return currentState == FighterStates.Defend 
				|| currentState == FighterStates.Take_Hit_Defend;
		}
	}

	public bool attacking {
		get {
			return currentState == FighterStates.Attack;
		}	
	}

	public float healtPercent {
		get {
			return healt / MAX_HEALTH;
		}	
	}

	public Rigidbody body {
		get {
			return this.myBody;
		}
	}
}
