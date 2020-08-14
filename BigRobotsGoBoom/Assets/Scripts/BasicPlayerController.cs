using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;

    public float currentMoveSpeed;
    void Update()
    {
        if (Input.GetKey(KeyCode.D) == true) { this.transform.position += this.transform.forward * Time.deltaTime * this.moveSpeed; }
        if (Input.GetKey(KeyCode.A) == true) { this.transform.position -= this.transform.forward * Time.deltaTime * this.moveSpeed; }
    }
}
