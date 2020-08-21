using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOneHealthBar : MonoBehaviour
{
    Image healthBar;
    float maxHealth = 100f;
    public static float health;

    private void Start()
    {
        healthBar = GetComponent<Image>();
        health = maxHealth;
    }

    private void Update()
    {
        healthBar.fillAmount = health / maxHealth;
    }
}
