using UnityEngine;
using System.Collections;

public class PaladinHitColider : MonoBehaviour
{
	public string attackName;
	public float damage;

	public FighterPaladin owner;

	void OnTriggerEnter(Collider other)
    {
        FighterSting somebody = other.gameObject.GetComponent<FighterSting> ();
        if (owner.attacking) 
        
			if (somebody != null && somebody != owner)
            {
				somebody.hurt (damage);
                Debug.Log("I hit " + somebody + " with " + attackName);
            }
	
	}
}
