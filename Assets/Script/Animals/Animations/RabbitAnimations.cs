using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitAnimations : MonoBehaviour
{
    private Animator animator;
    
    void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("IsMove", false);
    }
    public void Walk()
    {
        animator.SetBool("IsMove", true);
    }

    public void Idle()
    {
        animator.SetBool("IsMove", false);
    }
}
