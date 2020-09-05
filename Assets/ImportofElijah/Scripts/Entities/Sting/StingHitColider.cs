using UnityEngine;
using System.Collections;

public class StingHitColider : MonoBehaviour
{
    public string attackName;
    public float damage;

    public FighterSting owner;

    void OnTriggerEnter(Collider other)
    {
        FighterPaladin somebody = other.gameObject.GetComponent<FighterPaladin>();
        if (owner.attacking)

            if (somebody != null && somebody != owner)
            {
                somebody.hurt(damage);
                Debug.Log("I hit " + somebody + " with " + attackName);
            }

    }
}
