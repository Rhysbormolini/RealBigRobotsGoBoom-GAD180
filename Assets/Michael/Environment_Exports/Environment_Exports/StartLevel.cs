using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    protected Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("Start", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
