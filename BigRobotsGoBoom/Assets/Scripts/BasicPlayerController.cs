using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;

    public float currentMoveSpeed;

    protected Animator animator;
    void Update()
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
    }
}
