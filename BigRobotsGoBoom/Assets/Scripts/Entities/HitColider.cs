using UnityEngine;
using System.Collections;

public class HitColider : MonoBehaviour {
	public string punchName;
	public float damage;

	public Fighter owner;

	void OnTriggerEnter(Collider other){
		Fighter somebody = other.gameObject.GetComponent<Fighter> ();
		if (owner.attacking) {
			if (somebody != null && somebody != owner) {
				somebody.hurt (damage);
			}
		}
	}
}
