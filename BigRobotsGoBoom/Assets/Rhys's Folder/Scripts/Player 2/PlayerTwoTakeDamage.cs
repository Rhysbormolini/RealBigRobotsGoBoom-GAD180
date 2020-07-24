using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoTakeDamage : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "PlayerTwo")
        {
            PlayerTwoHealthBar.health -= 10f;
        }
    }
}
