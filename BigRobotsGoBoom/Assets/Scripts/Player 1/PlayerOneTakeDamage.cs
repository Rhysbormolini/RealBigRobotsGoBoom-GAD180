using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneTakeDamage : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag == "PlayerOne")
            {
                PlayerOneHealthBar.health -= 10f;
            }
        }
}
