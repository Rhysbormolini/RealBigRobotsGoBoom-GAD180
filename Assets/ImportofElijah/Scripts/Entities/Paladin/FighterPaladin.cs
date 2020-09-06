using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FighterPaladin : MonoBehaviour
{
    public enum PlayerType
    {
        HUMANPaladin, AIPaladin
    };

    public static float MAX_HEALTH = 100f;

    public float health = MAX_HEALTH;
    public string fighterName;
    public FighterSting oponent;
    public bool enable;

    public float moveSpeed;
    public float jumpHeight = 1f;

    public PlayerType player;
    public PaladinStates currentState = PaladinStates.Idle;

    protected Animator animator;
    private Rigidbody myBody;
    private AudioSource audioPlayer;

    //for AI only
    private float random;
    private float randomSetTime;
    //for jump animation stop
    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;
    bool isGrounded;

    public Transform shootBox;
    public Transform swordHandBox;

    public Transform sheild;
    bool isBlocking;
    public Transform eShootBox;
    public Transform eMeleeBox;

    public float delayedTime = 0.05f;

    // Use this for initialization
    void Start ()
    {
		myBody = GetComponent<Rigidbody> ();
		animator = GetComponent<Animator> ();
		audioPlayer = GetComponent<AudioSource> ();
	}

    public void UpdateHumanPaladinInput()
    {
       
        if (Input.GetKey(KeyCode.D) == true)
        {
            this.transform.position += this.transform.forward * Time.deltaTime * this.moveSpeed;
            animator.SetBool("Walk Forward", true);
        }
        else
        {
            animator.SetBool("Walk Forward", false);
        }

        if (Input.GetKey(KeyCode.A) == true)
            {
            this.transform.position -= this.transform.forward * Time.deltaTime * this.moveSpeed;
            animator.SetBool("Walk Backward", true);
            }
        else
        {
            animator.SetBool("Walk Backward", false);
        }

        //jump
        if (Input.GetKey(KeyCode.W) == true && Mathf.Abs(this.GetComponent<Rigidbody>().velocity.y) < 0.01f)
        {
			animator.SetBool("Jump", true);
			this.GetComponent<Rigidbody>().velocity += Vector3.up * this.jumpHeight;
			
			isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
		}
		else if (isGrounded == true)
		{
			animator.SetBool("Jump", false);
		}

        //combat
		if (Input.GetKey(KeyCode.C) == true)
        {
            animator.SetBool("Hit_Sword_0", true);
            Debug.Log("hit sword");
            swordHandBox.transform.GetComponent<BoxCollider>().enabled = true;
        }
        else
        {
            animator.SetBool("Hit_Sword_0", false);
            swordHandBox.transform.GetComponent<BoxCollider>().enabled = false;
        }
        
        if (Input.GetKey(KeyCode.V) == true)
        {
            animator.SetBool("Shoot", true);
            Debug.Log("hit gun");
			shootBox.transform.GetComponent<BoxCollider>().enabled = true;
		}
	
        else
        {
            animator.SetBool("Shoot", false);
			shootBox.transform.GetComponent<BoxCollider>().enabled = false;
		}

		if (Input.GetKeyDown(KeyCode.B) == true)
		{
			isBlocking = true;
			Blocking(isBlocking);
		}
		if (Input.GetKeyUp(KeyCode.B) == true)
		{
			isBlocking = false;
			Blocking(isBlocking);
		}
    } 

    public void UpdateAIPaladinInput()
    {
            animator.SetBool("defending", defending);
            //animator.SetBool ("invulnerable", invulnerable);
            //animator.SetBool ("enable", enable);

            animator.SetBool("oponent_attacking", oponent.attacking);
            animator.SetFloat("distanceToOponent", getDistanceToOponennt());

            if (Time.time - randomSetTime > 1)
            {
                random = Random.value;
                randomSetTime = Time.time;
            }
            animator.SetFloat("random", random);

        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Test Sword Hit"))
        {
            swordHandBox.transform.GetComponent<BoxCollider>().enabled = true;
            Debug.Log("hit sword");
        }
        else
        {
            swordHandBox.transform.GetComponent<BoxCollider>().enabled = false;
        }

        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Hit Gun"))
        {
            Debug.Log("hit gun");
            shootBox.transform.GetComponent<BoxCollider>().enabled = true;
        }

        else
        {
            shootBox.transform.GetComponent<BoxCollider>().enabled = false;
        }
    }

    //BLOCKING
    public void Blocking(bool b)
    {
        sheild.transform.GetComponent<MeshCollider>().enabled = b;
        sheild.transform.GetComponent<MeshRenderer>().enabled = b;
        eShootBox.transform.GetComponent<BoxCollider>().enabled = !b;
        eMeleeBox.transform.GetComponent<BoxCollider>().enabled = !b;
    }

    // Update is called once per frame
    void Update () {
       

        animator.SetFloat ("health", healthPercent);

		if (oponent != null)
        {
			animator.SetFloat ("oponent_health", oponent.healthPercent);
		}
        else
        {
			animator.SetFloat ("oponent_health", 1);
		}

		if (enable)
        {
			if (player == PlayerType.HUMANPaladin)
            {
				UpdateHumanPaladinInput ();
			}
            else
            {
                UpdateAIPaladinInput();
            }
		}


        if (health <= 0 && currentState != PaladinStates.Death)
        {
            animator.SetTrigger ("Death");
            Invoke("DelayedAction", delayedTime);
        }

 
    }

    void DelayedAction()
    {
        SceneManager.LoadScene(0); // reset to menu
    }

    private float getDistanceToOponennt(){
		return Mathf.Abs(transform.position.x - oponent.transform.position.x);
	}

	public virtual void hurt(float damage)
    {
		if (!invulnerable)
        {
			if (defending)
            {
				damage *= 0.2f;
			}
			if (health >= damage)
            {
				health -= damage;
			}
            else
            {
				health = 0;
			}

			if (health > 0) {
				animator.SetTrigger ("Take_Hit");
			}
		}
	}

	public void playSound(AudioClip sound)
    {
		GameUtils.playSound (sound, audioPlayer);
	}

	public bool invulnerable
    {
		get
        {
			return currentState == PaladinStates.Take_Hit 
				|| currentState == PaladinStates.Take_Hit_Defend
					|| currentState == PaladinStates.Death;
		}
	}

	public bool defending
    {
		get
        {
			return currentState == PaladinStates.Defend 
				|| currentState == PaladinStates.Take_Hit_Defend;
		}
	}

	public bool attacking
    {
		get
        {
			return currentState == PaladinStates.Attack;
		}	
	}

	public float healthPercent
    {
		get
        {
			return health / MAX_HEALTH;
		}	
	}

	public Rigidbody body
    {
		get
        {
			return this.myBody;
		}
	}
}
