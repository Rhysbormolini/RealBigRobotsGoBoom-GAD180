using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;

    public float currentMoveSpeed;
    void Update()
    { 
        if (Input.GetKey(KeyCode.D) == true)
        {
            this.transform.position += this.transform.forward* Time.deltaTime * this.moveSpeed;
            animator.SetBool("Walk Forward", true);
        }
        else
        {
            animator.SetBool("Walk Forward", false);
        }

        if (Input.GetKey(KeyCode.A) == true)
        {
            this.transform.position -= this.transform.forward* Time.deltaTime* this.moveSpeed;
            animator.SetBool("Walk Backward", true);
        }
        else
        {
            animator.SetBool("Walk Backward", false);
        }

        //jump
        if (Input.GetKey(KeyCode.W) == true && Mathf.Abs(this.GetComponent<Rigidbody>().velocity.y) < 0.01f)
        {
            this.GetComponent<Rigidbody>().velocity += Vector3.up * this.jumpHeight;
        }

        if (Input.GetKey(KeyCode.V) == true)
        {
             animator.SetBool("Hit_Sword_0", true);
             Debug.Log("hit sword");
        }
        else
        {
             animator.SetBool("Hit_Sword_0", false);
        }
    }
