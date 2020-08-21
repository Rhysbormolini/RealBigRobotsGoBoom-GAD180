using UnityEngine;
using System.Collections;

public class Hadoken : MonoBehaviour {
	public Fighter caster;
	public float movementForce = 200;	
	public float damage;

	private Rigidbody body;
	private float creationTime;

	// Use this for initialization
	void Start () {
		creationTime = Time.time;
		body = GetComponent<Rigidbody> ();
		body.AddRelativeForce (new Vector3 (movementForce, 0, 0));
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - creationTime > 3) {
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter (Collision col){
		Fighter fighter = col.gameObject.GetComponent<Fighter> ();
		if (fighter != null && fighter != caster) {
			fighter.hurt(damage);
			Destroy (gameObject);
		}
	}
}
